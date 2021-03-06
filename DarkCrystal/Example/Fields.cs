
// Copyright (c) Dark Crystal Games. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using DarkCrystal.FieldSystem;
using DarkCrystal.Serialization;

namespace DarkCrystal
{
    [DarkContract(TypeIndex.IntField), FieldType(typeof(int))]
    public enum IntField
    {
        AppleCount,
        OrangeCount,
        BananaCount

        // <- extend here
    }

    [DarkContract(TypeIndex.StringField), FieldType(typeof(string))]
    public enum StringField
    {
        Country,
        City,
        Notes

        // <- extend here
    }

    [DarkContract(TypeIndex.EntityField), FieldType(typeof(Entity))]
    public enum EntityField
    {
        Link

        // <- extend here
    }

    // <- add more field enums here

    namespace FieldSystem
    {
        public partial struct FieldKey
        {
            public static implicit operator FieldKey(IntField value) => value.ToFieldKey();
            public static implicit operator FieldKey(StringField value) => value.ToFieldKey();
            public static implicit operator FieldKey(EntityField value) => value.ToFieldKey();
        }
    }
}