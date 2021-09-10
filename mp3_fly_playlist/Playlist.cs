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

        public void Deserialize(BinaryReader sr)
        {
            if (sr.ReadChar() != 0x01)
                return;
            if(new string(sr.ReadChars(24)) != "MMIMP3_LIST_VER.01.01.00")
                return;
            if (sr.ReadUInt32()!= 0xFF)
                return;
            var count = sr.ReadUInt32();
            if(count!= sr.ReadUInt32())
                return;
            Items.Clear();
            for (var i = 0; i < count; ++i)
            {
                var item = new Mp3Item();
                item.Deserialize(sr);
                Items.Add(item);
            }
            if(sr.ReadUInt32()!=0x00)
                return;
            for (var i = 0; i < Items.Count; ++i)
            {
                if(sr.ReadUInt32()!=i)
                    return;
            }
            if (new string(sr.ReadChars(24)) != "MMIMP3_LIST_VER.01.01.00")
                return;
            var size = sr.BaseStream.Position + 12;
            if (sr.ReadUInt32() != size)
                return;
            if (sr.ReadUInt32() != Items.Count)
                return;
            if (sr.ReadUInt32() != Items.Count)
                return;
            if (sr.PeekChar() != -1)
                return;
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

        public void Load(string path)
        { 
            using (var memoryStream = new MemoryStream(File.ReadAllBytes(path)))
            using (var reader = new BinaryReader(memoryStream, Encoding.ASCII))
            { 
                Deserialize(reader);
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

        public void Deserialize(BinaryReader sr)
        {
            if(sr.ReadUInt32()!= 0x00)
                return;
            sr.ReadUInt32();
            Size = sr.ReadUInt32();
            var length = sr.ReadUInt16();
            if (length > 510)
                return;
            byte[] name = new byte[length];
            name = sr.ReadBytes(name.Length*2);
            SDPath = Encoding.Unicode.GetString(name);
            sr.ReadBytes(510 - name.Length);
            var path = SDPath;
            HDDPath = "D" + path.Substring(1);
            Name = Path.GetFileName(path);
            if(path.Substring(0,1) != "E")
                return;
            path = HDDPath;
            var fi = new FileInfo(path);
            if(Size != fi.Length)
                return;
        }

        public Mp3Item()
        {
        }

    }
}

