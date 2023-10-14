using System.Collections.Generic;

namespace LastSeenApplication
{
    public static class LocalizationService
    {
        private static Dictionary<string, Dictionary<string, string>> translations;

        static LocalizationService()
        {
            translations = new Dictionary<string, Dictionary<string, string>>
            {
                ["en"] = new Dictionary<string, string>
                {
                    ["Online"] = "Online",
                    ["WasOnline"] = "was online",
                    ["JustNow"] = "just now",
                    ["LessThanMinute"] = "less than a minute ago",
                    ["CoupleOfMinutes"] = "couple of minutes ago",
                    ["AnHourAgo"] = "an hour ago",
                    ["Today"] = "today",
                    ["Yesterday"] = "yesterday",
                    ["ThisWeek"] = "this week",
                    ["LongTimeAgo"] = "long time ago"
                },
                ["de"] = new Dictionary<string, string>
                {
                    ["Online"] = "Online",
                    ["WasOnline"] = "war online",
                    ["JustNow"] = "gerade eben",
                    ["LessThanMinute"] = "vor weniger als einer Minute",
                    ["CoupleOfMinutes"] = "vor ein paar Minuten",
                    ["AnHourAgo"] = "vor einer Stunde",
                    ["Today"] = "heute",
                    ["Yesterday"] = "gestern",
                    ["ThisWeek"] = "diese Woche",
                    ["LongTimeAgo"] = "vor langer Zeit"
                },
                ["ua"] = new Dictionary<string, string>
                {
                    ["Online"] = "В мережі",
                    ["WasOnline"] = "був в мережі",
                    ["JustNow"] = "щойно",
                    ["LessThanMinute"] = "менше хвилини тому",
                    ["CoupleOfMinutes"] = "кілька хвилин тому",
                    ["AnHourAgo"] = "годину тому",
                    ["Today"] = "сьогодні",
                    ["Yesterday"] = "вчора",
                    ["ThisWeek"] = "цього тижня",
                    ["LongTimeAgo"] = "давно"
                },
                ["es"] = new Dictionary<string, string>
                {
                    ["Online"] = "En línea",
                    ["WasOnline"] = "estuvo en línea",
                    ["JustNow"] = "justo ahora",
                    ["LessThanMinute"] = "hace menos de un minuto",
                    ["CoupleOfMinutes"] = "hace un par de minutos",
                    ["AnHourAgo"] = "hace una hora",
                    ["Today"] = "hoy",
                    ["Yesterday"] = "ayer",
                    ["ThisWeek"] = "esta semana",
                    ["LongTimeAgo"] = "hace mucho tiempo"
                },
                ["fr"] = new Dictionary<string, string>
                {
                    ["Online"] = "En ligne",
                    ["WasOnline"] = "était en ligne",
                    ["JustNow"] = "à l'instant",
                    ["LessThanMinute"] = "il y a moins d'une minute",
                    ["CoupleOfMinutes"] = "il y a quelques minutes",
                    ["AnHourAgo"] = "il y a une heure",
                    ["Today"] = "aujourd'hui",
                    ["Yesterday"] = "hier",
                    ["ThisWeek"] = "cette semaine",
                    ["LongTimeAgo"] = "il y a longtemps"
                }
            };
        }

        public static string GetText(string key, string language)
        {
            if (translations.ContainsKey(language) && translations[language].ContainsKey(key))
            {
                return translations[language][key];
            }
            else if (translations.ContainsKey("en") && translations["en"].ContainsKey(key))
            {
                return translations["en"][key];
            }

            return key;
        }
    }
}
