using Blackbird.Applications.Sdk.Common.Dictionaries;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Smartcat.DataSourceHandlers;

public class LanguageDataHandler : IStaticDataSourceHandler
{
    private static Dictionary<string, string> langs => new()
        {
            {"ab", "Abkhaz"}, {"ach-Latn", "Acholi"}, {"aa", "Afar"}, {"af", "Afrikaans"}, {"ak", "Akan"},
            {"sq", "Albanian"}, {"am", "Amharic"}, {"anp-Deva", "Angika"}, {"ar", "Arabic"},
            {"ar-DZ", "Arabic (Algeria)"}, {"ar-BH", "Arabic (Bahrain)"}, {"ar-EG", "Arabic (Egypt)"},
            {"ar-IQ", "Arabic (Iraq)"}, {"ar-IL", "Arabic (Israel)"}, {"ar-JO", "Arabic (Jordan)"},
            {"ar-KW", "Arabic (Kuwait)"}, {"ar-LB", "Arabic (Lebanon)"}, {"ar-MA", "Arabic (Morocco)"},
            {"ar-QA", "Arabic (Qatar)"}, {"ar-SA", "Arabic (Saudi Arabia)"}, {"ar-SD", "Arabic (Sudan)"},
            {"ar-AE", "Arabic (UAE)"}, {"hy", "Armenian"}, {"hy-arevela", "Armenian (Eastern)"},
            {"hy-arevmda", "Armenian (Western)"}, {"as", "Assamese (Bengali)"}, {"as-Latn", "Assamese (Latin)"},
            {"aii", "Assyrian Neo-Aramaic"}, {"rop-Latn", "Australian Kriol"}, {"av", "Avar"},
            {"az-Cyrl", "Azerbaijani (Cyrillic)"}, {"az-Latn", "Azerbaijani (Latin)"},
            {"bcc", "Balochi (Southern)"}, {"bm", "Bambara"}, {"ba", "Bashkir"}, {"eu", "Basque"},
            {"bsq-Latn", "Bassa"}, {"beq", "Beembe (Kibembe)"}, {"be", "Belarusian"}, {"bem-Latn", "Bemba"},
            {"bn", "Bengali"}, {"bho-Deva", "Bhojpuri"}, {"bh", "Bihari"}, {"bi-Latn", "Bislama"},
            {"brx-Deva", "Bodo"}, {"bs", "Bosnian"}, {"bg", "Bulgarian"}, {"bum", "Bulu (Bantu)"},
            {"my", "Burmese"}, {"kea", "Cape Verdean Creole"}, {"ca", "Catalan"}, {"ceb", "Cebuano"},
            {"esu", "Central Alaskan Yupʼik"}, {"aer-Latn", "Central-Eastern Arrernte"}, {"ce", "Chechen"},
            {"hne-Deva", "Chhattisgarhi (Devanagari)"}, {"hne-Orya", "Chhattisgarhi (Odia)"}, {"ny", "Chichewa"},
            {"yue", "Chinese (Cantonese)"}, {"zh-Latn-pinyin", "Chinese (Pinyin)"},
            {"zh-Hans", "Chinese (simplified)"}, {"zh-Hans-MY", "Chinese (simplified, Malaysia)"},
            {"zh-Hans-CN", "Chinese (simplified, PRC)"}, {"zh-Hans-SG", "Chinese (simplified, Singapore)"},
            {"zh-Hant", "Chinese (traditional)"}, {"zh-Hant-HK", "Chinese (traditional, Hong Kong)"},
            {"zh-Hant-MO", "Chinese (traditional, Macau)"}, {"zh-Hant-TW", "Chinese (traditional, Taiwan)"},
            {"ctg-Arab", "Chittagonian (Arabic)"}, {"ctg-Beng", "Chittagonian (Bengali)"},
            {"ctg-Latn", "Chittagonian (Latin)"}, {"cjk-Latn", "Chokwe"}, {"cac-Latn", "Chuj"},
            {"chk-Latn", "Chuukese"}, {"cv", "Chuvash"}, {"rar", "Cook Islands Māori"}, {"kw", "Cornish"},
            {"hr", "Croatian"}, {"cs", "Czech"}, {"da", "Danish"}, {"luo-Latn", "Dholuo"},
            {"dwu-Latn", "Dhuwal"}, {"din", "Dinka"}, {"doi-Arab", "Dogri (Arabic)"},
            {"doi-Deva", "Dogri (Devanagari)"}, {"doi-Dogr", "Dogri (Dogri)"}, {"nl", "Dutch"},
            {"nl-AW", "Dutch (Aruba)"}, {"nl-BE", "Dutch (Belgium)"},
            {"nl-BQ", "Dutch (Bonaire, Sint Eustatius and Saba)"}, {"nl-CW", "Dutch (Curaçao)"},
            {"nl-NL", "Dutch (Netherlands)"}, {"nl-SX", "Dutch (Sint Maarten)"}, {"nl-SR", "Dutch (Suriname)"},
            {"dyu-Arab", "Dyula (Arabic)"}, {"dyu-Latn", "Dyula (Latin)"}, {"dyu-Nkoo", "Dyula (N'Ko)"},
            {"dz", "Dzongkha"}, {"eky", "Eastern Kayah"}, {"en", "English"}, {"en-AU", "English (Australia)"},
            {"en-CA", "English (Canada)"}, {"en-IN", "English (India)"}, {"en-IE", "English (Ireland)"},
            {"en-NZ", "English (New Zealand)"}, {"en-PH", "English (Philippines)"},
            {"en-SG", "English (Singapore)"}, {"en-ZA", "English (South Africa)"},
            {"en-GB", "English (United Kingdom)"}, {"en-US", "English (USA)"}, {"eo", "Esperanto"},
            {"et", "Estonian"}, {"ee-Latn", "Ewe"}, {"cfm-Latn", "Falam Chin"}, {"fo", "Faroese"},
            {"fj", "Fijian"}, {"fil", "Filipino"}, {"fi", "Finnish"}, {"fon-Latn", "Fon"}, {"fr", "French"},
            {"fr-BE", "French (Belgium)"}, {"fr-CM", "French (Cameroon)"}, {"fr-CA", "French (Canada)"},
            {"fr-FR", "French (France)"}, {"fr-GH", "French (Ghana)"}, {"fr-CI", "French (Ivory Coast)"},
            {"fr-SN", "French (Senegal)"}, {"fr-CH", "French (Switzerland)"}, {"ff", "Fula"},
            {"gaa-Latn", "Ga"}, {"gl", "Galician"}, {"lg", "Ganda"}, {"grt-Beng", "Garo (Bengali)"},
            {"grt-Latn", "Garo (Latin)"}, {"ka", "Georgian"}, {"de", "German"}, {"de-AT", "German (Austria)"},
            {"de-DE", "German (Germany)"}, {"de-CH", "German (Switzerland)"}, {"gil-Latn", "Gilbertese"},
            {"el", "Greek"}, {"kl", "Greenlandic"}, {"gn", "Guarani"}, {"gu", "Gujarati"},
            {"guz-Arab", "Gusii (Arabic)"}, {"guz-Latn", "Gusii (Latin)"}, {"ht", "Haitian Creole"},
            {"cnh-Latn", "Hakha Chin"}, {"ha-Latn", "Hausa (Latin)"}, {"haw-Latn", "Hawaiian"},
            {"haz", "Hazaragi"}, {"he", "Hebrew"}, {"hz", "Herero"}, {"hil-Latn", "Hiligaynon"},
            {"hi", "Hindi"}, {"hmn", "Hmong"}, {"hu", "Hungarian"}, {"is", "Icelandic"}, {"ig", "Igbo"},
            {"ikw", "Ikwere"}, {"ilo-Latn", "Ilocano"}, {"id", "Indonesian"}, {"inh", "Ingush"},
            {"ga", "Irish"}, {"it", "Italian"}, {"it-IT", "Italian (Italy)"},
            {"it-CH", "Italian (Switzerland)"}, {"ium-Latn", "Iu Mien"}, {"ja", "Japanese"}, {"jv", "Javanese"},
            {"dyo-Latn", "Jola"}, {"pga-Latn", "Juba Arabic (Latin)"}, {"kbd-Cyrl", "Kabardian"},
            {"kab", "Kabyle"}, {"bjj-Deva", "Kanauji"}, {"kn", "Kannada"}, {"kqn-Latn", "Kaonde"},
            {"kar-Mymr", "Karen"}, {"ks-Arab", "Kashmiri (Arabic)"}, {"ks-Deva", "Kashmiri (Devanagari)"},
            {"kk", "Kazakh"}, {"kha-Beng", "Khasi"}, {"km", "Khmer"}, {"cgg-Latn", "Kiga"},
            {"ki-Latn", "Kikuyu"}, {"kmb-Latn", "Kimbundu"}, {"rw", "Kinyarwanda"}, {"rn", "Kirundi"},
            {"kv", "Komi"}, {"kok", "Konkani (Devanagari)"}, {"kok-Latn", "Konkani (Latin)"},
            {"koo-Latn", "Konzo"}, {"ko", "Korean"}, {"kri", "Krio"}, {"kmr-Latn", "Kurdish (Kurmandji)"},
            {"sdh-Arab", "Kurdish (Palewani)"}, {"ckb-Arab", "Kurdish (Sorani)"}, {"kj-Latn", "Kwanyama"},
            {"ky", "Kyrgyz"}, {"quc-Latn", "Kʼicheʼ"}, {"lam-Latn", "Lamba"}, {"laj-Latn", "Lango"},
            {"lo", "Lao"}, {"la", "Latin"}, {"lv", "Latvian"}, {"leh-Latn", "Lenje"}, {"li", "Limburgish"},
            {"ln", "Lingala"}, {"lt", "Lithuanian"}, {"loz", "Lozi"}, {"lua-Latn", "Luba-Kasai"},
            {"lch-Latn", "Luchazi"}, {"luy-Latn", "Luhya"}, {"lun-Latn", "Lunda"}, {"lue-Latn", "Luvale"},
            {"lb", "Luxembourgish"}, {"mas-Latn", "Maasai"}, {"mca", "Maca"}, {"mk", "Macedonian"},
            {"mad-Arab", "Madurese (Arabic)"}, {"mad-Java", "Madurese (Javanese)"},
            {"mad-Latn", "Madurese (Latin)"}, {"mag-Deva", "Magahi"}, {"mai", "Maithili"},
            {"vmw-Latn", "Makhuwa"}, {"mg", "Malagasy"}, {"ms", "Malay"}, {"ms-MY", "Malay (Malaysia)"},
            {"ms-SG", "Malay (Singapore)"}, {"ml", "Malayalam"}, {"mt", "Maltese"}, {"mam-Latn", "Mam"},
            {"mnk-Arab", "Mandinka (Arabic)"}, {"mnk-Latn", "Mandinka (Latin)"}, {"mnk-Nkoo", "Mandinka (N'Ko)"},
            {"mi", "Maori"}, {"mr", "Marathi"}, {"mhr", "Mari"}, {"mh", "Marshallese"},
            {"mni-Beng", "Meitei (Bengali)"}, {"mni-Latn", "Meitei (Latin)"}, {"mni-Mtei", "Meitei (Meitei)"},
            {"lus-Latn", "Mizo"}, {"mn", "Mongolian"}, {"cnr-Latn", "Montenegrin"},
            {"mos-Latn", "Mooré (Latin)"}, {"mos-Nkoo", "Mooré (N'Ko)"}, {"sck-Deva", "Nagpuri"},
            {"nv-Latn", "Navaho"}, {"ng-Latn", "Ndonga"}, {"ne", "Nepali"}, {"pcm", "Nigerian Pidgin"},
            {"niu", "Niuean"}, {"nyn-Latn", "Nkore"}, {"nd", "Northern Ndebele"}, {"nso", "Northern Sotho"},
            {"no", "Norwegian"}, {"nb", "Norwegian (Bokmål)"}, {"nn", "Norwegian (Nynorsk)"}, {"nus", "Nuer"},
            {"nyo-Latn", "Nyoro"}, {"oc", "Occitan"}, {"or", "Odia"}, {"om", "Oromo"}, {"os", "Ossetian"},
            {"pap", "Papiamento"}, {"pap-AW", "Papiamento (Aruba)"},
            {"pap-BQ", "Papiamentu (Bonaire, Sint Eustatius and Saba)"}, {"pap-CW", "Papiamentu (Curaçao)"},
            {"ps", "Pashto"}, {"fa", "Persian"}, {"fa-AF", "Persian (Afghanistan) / Dari"},
            {"fa-IR", "Persian (Iran)"}, {"pis-Latn", "Pijin"}, {"pjt-Latn", "Pitjantjatjara"},
            {"pon-Latn", "Pohnpeian"}, {"pl", "Polish"}, {"pt", "Portuguese"}, {"pt-BR", "Portuguese (Brazil)"},
            {"pt-PT", "Portuguese (Portugal)"}, {"fuc-Adlm", "Pulaar (Adlam)"}, {"fuc-Arab", "Pulaar (Arabic)"},
            {"fuc-Latn", "Pulaar (Latin)"}, {"pa", "Punjabi (Gurmukhi)"}, {"pa-Arab", "Punjabi (Shahmukhi)"},
            {"kek-Latn", "Qʼeqchiʼ"}, {"lag-Latn", "Rangi"}, {"rhg-Rohg", "Rohingya (Hanifi)"},
            {"rhg-Latn", "Rohingya (Latin)"}, {"ro", "Romanian"}, {"ro-MD", "Romanian (Moldova)"},
            {"ro-RO", "Romanian (Romania)"}, {"nbu-Latn", "Rongmei (Latin)"}, {"nbu-Mtei", "Rongmei (Meitei)"},
            {"ru", "Russian"}, {"ru-BY", "Russian (Belarus)"}, {"ru-KZ", "Russian (Kazakhstan)"},
            {"ru-RU", "Russian (Russia)"}, {"ksw-Mymr", "S'gaw Karen (Burmese)"},
            {"ksw-Latn", "S'gaw Karen (Latin)"}, {"sah", "Sakha"}, {"sm", "Samoan"}, {"sg", "Sango"},
            {"sa", "Sanskrit"}, {"sat-Beng", "Santali (Bengali)"}, {"sat-Latn", "Santali (Latin)"},
            {"sat-Orya", "Santali (Odia)"}, {"sat-Olck", "Santali (Ol Chiki)"}, {"skr-Arab", "Saraiki"},
            {"sc", "Sardinian"}, {"gd-Latn", "Scottish Gaelic"}, {"sr-Cyrl", "Serbian (Cyrillic)"},
            {"sr-Latn", "Serbian (Latin)"}, {"srr-Latn", "Serer"}, {"st", "Sesotho"}, {"shn-Mymr", "Shan"},
            {"sn", "Shona"}, {"sd", "Sindhi"}, {"si", "Sinhalese"}, {"sk", "Slovak"}, {"sl", "Slovenian"},
            {"so", "Somali"}, {"nr", "Southern Ndebele"}, {"es", "Spanish"}, {"es-AR", "Spanish (Argentina)"},
            {"es-CL", "Spanish (Chile)"}, {"es-CO", "Spanish (Colombia)"}, {"es-GT", "Spanish (Guatemala)"},
            {"es-419", "Spanish (Latin America)"}, {"es-MX", "Spanish (Mexico)"},
            {"es-NI", "Spanish (Nicaragua)"}, {"es-PE", "Spanish (Peru)"}, {"es-PR", "Spanish (Puerto Rico)"},
            {"es-ES", "Spanish (Spain)"}, {"es-US", "Spanish (USA)"}, {"su", "Sundanese"}, {"sus", "Susu"},
            {"sw", "Swahili"}, {"ss", "Swati"}, {"sv", "Swedish"}, {"tl", "Tagalog"}, {"tg", "Tajik"},
            {"ta", "Tamil"}, {"tt", "Tatar"}, {"ctd-Latn", "Tedim Chin"}, {"te", "Telugu"}, {"tet", "Tetum"},
            {"th", "Thai"}, {"bo", "Tibetan"}, {"ti", "Tigrinya"}, {"tiw-Latn", "Tiwi"},
            {"toi-Latn", "Tonga"}, {"to", "Tongan"}, {"ttj-Latn", "Tooro"},
            {"tcs-Latn", "Torres Strait Creole"}, {"ts", "Tsonga"}, {"tn", "Tswana"}, {"tr", "Turkish"},
            {"tk", "Turkmen"}, {"tw-Latn", "Twi"}, {"udm", "Udmurt"}, {"uk", "Ukrainian"}, {"ur", "Urdu"},
            {"ug", "Uyghur"}, {"uz-Cyrl", "Uzbek (Cyrillic)"}, {"uz-Latn", "Uzbek (Latin)"}, {"ve", "Venda"},
            {"vi", "Vietnamese"}, {"rmy-Cyrl", "Vlax Romani (Cyrillic)"}, {"rmy-Latn", "Vlax Romani (Latin)"},
            {"wbp-Latn", "Warlpiri"}, {"cy", "Welsh"}, {"are-Latn", "Western Arrernte"}, {"wo", "Wolof"},
            {"xh", "Xhosa"}, {"yi", "Yiddish"}, {"yo", "Yoruba"}, {"zu", "Zulu"}

        };
    public Dictionary<string, string> GetData()
    {
        return langs;
    }
}