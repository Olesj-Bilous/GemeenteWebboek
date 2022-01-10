﻿using ForumData.Entities;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWeb
{
    //met dank aan https://www.talkingdotnet.com/store-complex-objects-in-asp-net-core-session/
    public static class SessionExtensions
    {
        public static Persoon GetUser(this ISession session)
        {
            bool? isMedewerker = session.GetBoolean("IsMedewerker");
            if (isMedewerker is not null)
                return (bool)isMedewerker
                    ? session.GetObject<Medewerker>("Gebruiker")
                    : session.GetObject<Profiel>("Gebruiker");
            else
                return null;

        }
        public static void SetObject(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            string value = session.GetString(key);
            return value is null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
        public static void SetBoolean(this ISession session, string key, bool value)
        {
            session.Set(key, BitConverter.GetBytes(value));
        }

        public static bool? GetBoolean(this ISession session, string key)
        {
            byte[] data = session.Get(key);
            return data is null ? null : BitConverter.ToBoolean(data, 0);
        }
    }
}
