﻿
using System;
using MessagePack;
using MessagePack.Formatters;

namespace DarkCrystal.Serialization
{
    public class GuidFormatter : IMessagePackFormatter<Guid>
    {
        public int Serialize(ref byte[] bytes, int offset, Guid guid, IFormatterResolver formatterResolver)
        {
            if (Serializer.Instance.State.IsText)
            {
                return MessagePackBinary.WriteString(ref bytes, offset, guid.ToString());
            }
            else
            {
                return MessagePackBinary.WriteBytes(ref bytes, offset, guid.ToByteArray());
            }
        }

        public Guid Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
        {
            if (Serializer.Instance.State.IsText)
            {
                var guidString = MessagePackBinary.ReadString(bytes, offset, out readSize);
                return new Guid(guidString);
            }
            else
            {
                var guidBytes = MessagePackBinary.ReadBytes(bytes, offset, out readSize);
                return new Guid(guidBytes);
            }
        }
    }
}