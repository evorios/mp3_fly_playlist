using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace mp3_fly_playlist
{
    class Playlist
    {
        private static Playlist _playlist { get; set; }

        public static Playlist Singleton
        {
            get
            {
                return _playlist = _playlist ?? new Playlist();
            }
        }

        Playlist()
        {
            Items = new BindingList<Mp3Item>();
        }

        public IList<Mp3Item> Items { get; set; }

        public void AddDirectory(string path)
        {
            path = Path.GetDirectoryName(path);
            if (!Directory.Exists(path))
                return;

            AddFiles(Directory.GetFiles(path, "*.mp3", SearchOption.AllDirectories));
        }

        public void AddFiles(string[] files)
        {
            foreach (var file in files)
            {
                Items.Add(new Mp3Item(file));
            }
        }

        public void DeleteItems(Mp3Item[] items)
        {
            foreach (var item in items)
            {
                Items.Remove(item);
            }
        }

        public void Serialize(BinaryWriter sw)
        {
            sw.Write((char)0x01);
            sw.Write("MMIMP3_LIST_VER.01.01.00".ToCharArray());
            sw.Write((UInt32)0xFF);
            sw.Write((UInt32)Items.Count);
            sw.Write((UInt32)Items.Count);

            for (var i = 0; i < Items.Count; ++i)
            {
                Items[i].Serialize(sw);
            }

            sw.Write((UInt32)0x00);

            for (var i = 0; i < Items.Count; ++i)
            {
                sw.Write((UInt32)i);
            }

            sw.Write("MMIMP3_LIST_VER.01.01.00".ToCharArray());
            var size = sw.BaseStream.Position + 12;
            sw.Write((UInt32)size);
            sw.Write((UInt32)Items.Count);
            sw.Write((UInt32)Items.Count);
        }

        public Playlist(string path)
        {
            Items = new BindingList<Mp3Item>();
            //
        }

        public void Save(string path)
        {
            using (var memoryStream = new MemoryStream())
            using (var writer = new BinaryWriter(memoryStream, Encoding.ASCII))
            {
                Serialize(writer);
                File.WriteAllBytes(path, memoryStream.ToArray());
            }
        }

        public void MoveUpItems(Mp3Item[] items)
        {
            foreach (var item in items)
            {
                //
            }
        }

        public void MoveDownItems(Mp3Item[] items)
        {
            foreach (var item in items)
            {
                //
            }
        }
    }

    class Mp3Item
    {
        public Mp3Item(string path)
        {
            HDDPath = path;
            Name = Path.GetFileName(path);
            SDPath = "E" + path.Substring(1);
            var fi = new FileInfo(path);
            Size = fi.Length;
        }

        public string Name { get; set; }
        public string HDDPath { get; set; }
        public string SDPath { get; set; }
        public long Size { get; set; }

        public void Serialize(BinaryWriter sw)
        {
            sw.Write((UInt32)0x00);
            sw.Write((UInt32)0x00);
            sw.Write((UInt32)Size);
            sw.Write((UInt16)SDPath.Length);

            byte[] name = Encoding.Unicode.GetBytes(SDPath);
            Array.Resize<byte>(ref name, 510);
            sw.Write(name);
        }
    }
}

