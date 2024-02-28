namespace DigitaleSigner
{
    class StringEN
    {
        #region Main interface

        //dialogs
        internal static string PDFFileFilter = "PDF Documents *.pdf|*.pdf";

        //messagebox
        internal static string MessageBoxError = "Error";
        internal static string MessageBoxErrorPFX = "Generate .PFX Error!";
        internal static string MessageBoxWarning = "Warning";
        internal static string MessageBoxInformation = "Information";
        internal static string MessageBoxSelectSourceFile = "Select the source file!";
        internal static string MessageBoxSelectDestinationFile = "Select the destination file!";
        internal static string MessageBoxDestinationSourceSameFile = "The destination file is the same as the source file!";
        internal static string MessageBoxDestinationFileExists = "The destination file already exists!";
        internal static string MessageBoxFileSignedSuccessfully = "The file was signed successfully!";
        internal static string MessageBoxFolderSignedFinised = "Operation finished!";
        internal static string MessageBoxTSAServerURL = "Time stamping server URL cannot be empty!";

        //dialogs
        internal static string openPDFFileTitle = "Select the PDF document";
        internal static string signedFileSuffix = "[signed]";
        internal static string savePDFSignedFileTitle = "Save the PDF document";

        //toolstrip
        internal static string toolStripSelectedFile = "Selected file: ";

        //image
        internal static string ImageFileFilter = "All Image Files|*.bmp;*.gif;*.jpg;*.jpeg;*.png;*.tif;*.tiff;*.wmf|Bitmap Files (*.bmp)|*.bmp|GIF Files (*.gif)|*.gif|JPEG Files (*.jpg, *.jpeg)|*.jpg;*.jpeg|PNG Files (*.png)|*.png|TIFF Files (*.tif, *.tiff)|*.tif;*.tiff|WMF Files (*.wmf)|*.wmf";
        internal static string openImageFileTitle = "Select the signature image";
        internal static string invalidNumericArgument = "Invalid numeric argument for signature position";
        internal static string imageNotExists = "To add an image on the signature rectangle please select an image file.";
        #endregion

        #region Certificate Selection

        //dialogs
        internal static string CertificateSelection = "Signing certificate";
        internal static string selectTheDigitalCertificate = "Select the digital certificate used for signing";
        internal static string radioButtonWindowsCertStore = "Windows Certificate Store";
        internal static string groupBoxWindowsCertificateStore = "Installed certificates";
        internal static string checkBoxValidOnly = "Use only valid certificates";
        internal static string buttonShowSigninigCertificate = "Show certificate";
        internal static string radioButtonPFXCert = "PFX digital certificate file";
        internal static string groupBoxPFXCertificate = "PFX certificate file";
        internal static string PFXFilePassword = "PFX file password:";
        internal static string linkLabelCertificates = "Get a digital certificate";
        internal static string buttonCancel = "Cancel";
        internal static string buttonOK = "Apply signature";

        internal static string validUntil = " valid until ";
        internal static string issuedBy = " issued by ";
        internal static string noCertificatesFound = "No digital certificates was found on your system";
        internal static string theSelectedPFXCannotBeFound = "The selected PFX signing certificate cannot be found";
        internal static string PFXCertificateError = "PFX certificate error: ";
        internal static string openPFXFileTitle = "Select the PFX certificate";
        internal static string PFXFileFilter = "PFX digital certificates *.pfx|*.pfx";

        #endregion
    }
}
