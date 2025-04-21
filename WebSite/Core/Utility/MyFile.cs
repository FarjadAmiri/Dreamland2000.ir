using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;


namespace WebSite.Core.Utility
{
    public class MyFile
    {

        static string[] mediaExtensions = {
            ".PNG", ".JPG", ".JPEG", ".BMP", ".GIF", //etc
            ".WAV", ".MID", ".MIDI", ".WMA", ".MP3", ".OGG", ".RMA", //etc
            ".AVI", ".MP4", ".DIVX", ".WMV", //etc
        };


       
            public static byte[] BitmapToByteArray(Bitmap bitmap)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    bitmap.Save(ms, ImageFormat.Png);
                    return ms.ToArray();
                }
            }
       
    public void Image_resize(string inputImagePath, string outputImagePath, int newWidth)
        {

            const long quality = 50L;

            Bitmap sourceBitmap = new Bitmap(inputImagePath);



            double dblWidthOrigial = sourceBitmap.Width;

            double dblHeigthOrigial = sourceBitmap.Height;

            double relationHeigthWidth = dblHeigthOrigial / dblWidthOrigial;

            int newHeight = (int)(newWidth * relationHeigthWidth);



            //< create Empty Drawarea >

            var newDrawArea = new Bitmap(newWidth, newHeight);

            //</ create Empty Drawarea >



            using (var graphicOfDrawArea = Graphics.FromImage(newDrawArea))

            {

                //< setup >

                graphicOfDrawArea.CompositingQuality = CompositingQuality.HighSpeed;

                graphicOfDrawArea.InterpolationMode = InterpolationMode.HighQualityBicubic;

                graphicOfDrawArea.CompositingMode = CompositingMode.SourceCopy;

                //</ setup >



                //< draw into placeholder >

                //*imports the image into the drawarea

                graphicOfDrawArea.DrawImage(sourceBitmap, 0, 0, newWidth, newHeight);

                //</ draw into placeholder >



                //--< Output as .Jpg >--

                using (var output = File.Open(outputImagePath, FileMode.Create))

                {

                    //< setup jpg >

                    var qualityParamId = Encoder.Quality;

                    var encoderParameters = new EncoderParameters(1);

                    encoderParameters.Param[0] = new EncoderParameter(qualityParamId, quality);

                    //</ setup jpg >



                    //< save Bitmap as Jpg >

                    var codec = ImageCodecInfo.GetImageDecoders().FirstOrDefault(c => c.FormatID == ImageFormat.Jpeg.Guid);

                    newDrawArea.Save(output, codec, encoderParameters);

                    //resized_Bitmap.Dispose ();

                    output.Close();

                    //</ save Bitmap as Jpg >

                }

                //--</ Output as .Jpg >--

                graphicOfDrawArea.Dispose();

            }

            sourceBitmap.Dispose();

            //---------------</ Image_resize() >---------------

        }

        
        public static bool IsImage(IFormFile file)
        {
            try
            {
                var img = System.Drawing.Image.FromStream(file.OpenReadStream());

                //-------------------------------------------
                //  Check the image mime types
                //-------------------------------------------
                if (!string.Equals(file.ContentType, "image/jpg", StringComparison.OrdinalIgnoreCase) &&
                    !string.Equals(file.ContentType, "image/jpeg", StringComparison.OrdinalIgnoreCase) &&
                    !string.Equals(file.ContentType, "image/pjpeg", StringComparison.OrdinalIgnoreCase) &&
                    !string.Equals(file.ContentType, "image/gif", StringComparison.OrdinalIgnoreCase) &&
                    !string.Equals(file.ContentType, "image/x-png", StringComparison.OrdinalIgnoreCase) &&
                    !string.Equals(file.ContentType, "image/png", StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }

                //-------------------------------------------
                //  Check the image extension
                //-------------------------------------------
                var postedFileExtension = Path.GetExtension(file.FileName);
                if (!string.Equals(postedFileExtension, ".jpg", StringComparison.OrdinalIgnoreCase)
                    && !string.Equals(postedFileExtension, ".png", StringComparison.OrdinalIgnoreCase)
                    && !string.Equals(postedFileExtension, ".gif", StringComparison.OrdinalIgnoreCase)
                    && !string.Equals(postedFileExtension, ".jpeg", StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }


        public static bool IsFile(IFormFile file)
        {
            try
            {
                var postedFileExtension = Path.GetExtension(file.FileName);
                if (!string.Equals(postedFileExtension, ".pdf", StringComparison.OrdinalIgnoreCase)
                    && !string.Equals(postedFileExtension, ".doc", StringComparison.OrdinalIgnoreCase)
                    && !string.Equals(postedFileExtension, ".xls", StringComparison.OrdinalIgnoreCase)
                    && !string.Equals(postedFileExtension, ".docx", StringComparison.OrdinalIgnoreCase)
                    && !string.Equals(postedFileExtension, ".xlsx", StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }


        public static bool IsVideo(IFormFile file)
        {
            if (!string.Equals(file.ContentType, "video/mp4", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            var postedFileExtension = Path.GetExtension(file.FileName);
            if (!string.Equals(postedFileExtension, ".mp4", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            return true;

        }
        
        public static bool IsValidVideoSize(IFormFile file)
        {
            int maxFileSize = 5000000; //byte (5MB)
            int fileSize = (int)file.Length;
            if (fileSize > maxFileSize)
            {
                return false;
            }
            return true;

        }

        public static bool IsValidPhotoSize(IFormFile file)
        {
            int maxFileSize = 2000000; //byte (2MB)
            int fileSize = (int)file.Length;
            if (fileSize > maxFileSize)
            {
                return false;
            }
            return true;

        }

        static bool IsMediaFile(string path)
        {
            return -1 != Array.IndexOf(mediaExtensions, Path.GetExtension(path).ToUpperInvariant());
        }
    }
}
