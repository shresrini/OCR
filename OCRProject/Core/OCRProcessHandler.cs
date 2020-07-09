using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using tesseract;

namespace ImageProcessing.Core
{
    public enum TesseractEngineMode : int
    {
        /// <summary>
        /// Run Tesseract only - fastest
        /// </summary>
        TESSERACT_ONLY = 0,

        /// <summary>
        /// Run Cube only - better accuracy, but slower
        /// </summary>
        CUBE_ONLY = 1,

        /// <summary>
        /// Run both and combine results - best accuracy
        /// </summary>
        TESSERACT_CUBE_COMBINED = 2,

        /// <summary>
        /// Specify this mode when calling init_*(),
        /// to indicate that any of the above modes
        /// should be automatically inferred from the
        /// variables in the language-specific config,
        /// command-line configs, or if not specified
        /// in any of the above should be set to the
        /// default OEM_TESSERACT_ONLY.
        /// </summary>
        DEFAULT = 3
    }
    public enum TesseractPageSegMode : int
    {
        /// <summary>
        /// Fully automatic page segmentation
        /// </summary>
        PSM_AUTO = 0,

        /// <summary>
        /// Assume a single column of text of variable sizes
        /// </summary>
        PSM_SINGLE_COLUMN = 1,

        /// <summary>
        /// Assume a single uniform block of text (Default)
        /// </summary>
        PSM_SINGLE_BLOCK = 2,

        /// <summary>
        /// Treat the image as a single text line
        /// </summary>
        PSM_SINGLE_LINE = 3,

        /// <summary>
        /// Treat the image as a single word
        /// </summary>
        PSM_SINGLE_WORD = 4,

        /// <summary>
        /// Treat the image as a single character
        /// </summary>
        PSM_SINGLE_CHAR = 5
    }

    public class OCRProcessHandler
    {
        private static TesseractProcessor m_tesseract = null;
        private const string TESSERACT_PAGE_SEGMENTATION_MODE = "tessedit_pageseg_mode";

        public TesseractProcessor TesseractInstance
        {
            get { return m_tesseract; }
            set { m_tesseract = value; }
        }
        private string m_path = Properties.Settings.Default.tessedataPath;
        private string m_lang = Properties.Settings.Default.defaultLang;

        public bool Initialize(TesseractEngineMode engMode)
        {
            System.Environment.CurrentDirectory = System.IO.Path.GetFullPath(m_path);
            m_tesseract = new TesseractProcessor();
            return m_tesseract.Init(m_path, m_lang, (int)engMode);
        }

        public bool SetVariable(TesseractPageSegMode segMode)
        {
            try
            {
                m_tesseract.SetVariable(TESSERACT_PAGE_SEGMENTATION_MODE, ((int)segMode).ToString());
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string DoOCR(Image image)
        {
            m_tesseract.Clear();
            m_tesseract.ClearAdaptiveClassifier();
            return m_tesseract.Apply(image);
        }
    }
}
