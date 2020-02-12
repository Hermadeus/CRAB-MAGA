using System.Collections;
using System;
using UnityEngine;

namespace CRABMAGA
{
    public class LanguageSysteme : MonoBehaviour
    {

    }

    [Serializable]
    public class StringLanguage : ITextLanguagable
    {
        [SerializeField] string frenchVersion;
        [SerializeField] string englishVersion;
        public string FrenchVersion { get => frenchVersion; set => frenchVersion = value; }
        public string EnglishVersion { get => englishVersion; set => englishVersion = value; }

        public string GetCurrentVersion(LanguageEnum languageEnum)
        {
            switch (languageEnum.language)
            {
                case Language.FRANCAIS:
                    return frenchVersion;
                case Language.ENGLISH:
                    return englishVersion;
                default:
                    return null;
            }
        }
    }

    [Serializable]
    public class TextLanguage : ITextLanguagable
    {
        [SerializeField,TextArea(3,5)] string frenchVersion;
        [SerializeField,TextArea(3,5)] string englishVersion;
        public string FrenchVersion { get => frenchVersion; set => frenchVersion = value; }
        public string EnglishVersion { get => englishVersion; set => englishVersion = value; }

        public string GetCurrentVersion(LanguageEnum languageEnum)
        {
            switch (languageEnum.language)
            {
                case Language.FRANCAIS:
                    return frenchVersion;
                case Language.ENGLISH:
                    return englishVersion;
                default:
                    return null;
            }
        }
    }

    public interface ITextLanguagable
    {
        string FrenchVersion { get; set; }
        string EnglishVersion { get; set; }
    }


}