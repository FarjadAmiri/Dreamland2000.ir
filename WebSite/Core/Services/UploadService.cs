using System.Drawing;
using System.Drawing.Imaging;
using WebSite.Core.Utility;
using ZXing.QrCode;


namespace WebSite.Core.Services
{
    public interface IUploadService
    {
        string GenerateQrCode(string url, string path);
        string UploadPhoto(IFormFile uploadPhoto, string path);

        string UploadOriginalPhoto(IFormFile uploadPhoto, string path);


        string UploadSlider(IFormFile uploadPhoto, string path);

        string UploadVideo(IFormFile uploadVideo, string path);
        
        string UploadFile(IFormFile uploadFile, string path);

        string UploadMusic(IFormFile uploadMusic, string path);
        
        bool RemovePhoto(string photoName, string path);
        
        bool RemoveVideo(string videoName, string path);

        bool RemoveMusic(string musicName, string path);
        bool RemoveFile(string fileName, string path);


    }
    public class UploadService : IUploadService
    {
        public string GenerateQrCode(string url, string path)
        {
            Byte[] byteArray;
            var width = 250; // width of the Qr Code   
            var height = 250; // height of the Qr Code   
            var margin = 0;
            var qrCodeWriter = new ZXing.BarcodeWriterPixelData
            {
                Format = ZXing.BarcodeFormat.QR_CODE,
                Options = new QrCodeEncodingOptions
                {
                    Height = height,
                    Width = width,
                    Margin = margin
                }
            };
            var pixelData = qrCodeWriter.Write(url);

            using (var bitmap = new Bitmap(pixelData.Width, pixelData.Height, PixelFormat.Format32bppRgb))
            {
                using (var ms = new MemoryStream())
                {
                    var bitmapData =
                        bitmap.LockBits(new Rectangle(0, 0, pixelData.Width, pixelData.Height),
                            ImageLockMode.WriteOnly,
                            PixelFormat.Format32bppRgb);
                    try
                    {

                        System.Runtime.InteropServices.Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0,
                            pixelData.Pixels.Length);
                    }
                    finally
                    {
                        bitmap.UnlockBits(bitmapData);
                    }

                    string qrCodeName = MyGenerator.GenerateStringUniqCode() + ".png";
                    string qrCodePath = path + qrCodeName;

                    bitmap.Save(qrCodePath, ImageFormat.Png);
                    bitmap.Save(ms, ImageFormat.Png);

                    return qrCodeName;
                }
            }
        }

        public string UploadPhoto(IFormFile uploadPhoto, string path)
        {
            string photoName = MyGenerator.GenerateStringUniqCode() + Path.GetExtension(uploadPhoto.FileName);

            //upload temp photo 
            string tempPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload/temp", photoName);
            using (var stream = new FileStream(tempPath, FileMode.Create))
            {
                uploadPhoto.CopyTo(stream);
            }
            

            //resize and save photo 
            MyFile resize = new MyFile();
            string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), path, photoName);
            resize.Image_resize(tempPath, uploadPath, 800);
            

            //resize and save photo 
            path = path + "/thumb";
            string thumbnailPath = Path.Combine(Directory.GetCurrentDirectory(), path, photoName);
            resize.Image_resize(tempPath, thumbnailPath, 400);
            

            //delete temp photo 
            if (File.Exists(tempPath))
            {
                File.Delete(tempPath);
            }
            

            return photoName;
        }

        public  string UploadOriginalPhoto(IFormFile uploadPhoto, string path)
        {
            
            string photoName = MyGenerator.GenerateStringUniqCode() + Path.GetExtension(uploadPhoto.FileName);

            //upload original photo 
            string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), path, photoName);
            using (var stream = new FileStream(uploadPath, FileMode.Create))
            {
                uploadPhoto.CopyTo(stream);
            }
            

            //resize and save thumbnail photo 
            MyFile resize = new MyFile();
            path = path + "/thumb";
            string thumbnailPath = Path.Combine(Directory.GetCurrentDirectory(), path, photoName);
            resize.Image_resize(uploadPath, thumbnailPath, 400);
            

            return photoName;
        }

        public string UploadSlider(IFormFile uploadPhoto, string path)
        {
            
            string photoName = MyGenerator.GenerateStringUniqCode() + Path.GetExtension(uploadPhoto.FileName);

            //resize and save photo 
            
            string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), path, photoName);
            using (var stream = new FileStream(uploadPath, FileMode.Create))
            {
                uploadPhoto.CopyTo(stream);
            }
            //resize.Image_resize(tempPath, uploadPath, 1600);
            

            //resize and save photo 
            MyFile resize = new MyFile();
            path = path + "/thumb";
            string thumbnailPath = Path.Combine(Directory.GetCurrentDirectory(), path, photoName);
            resize.Image_resize(uploadPath, thumbnailPath, 400);
            

            return photoName;
        }

        public string UploadVideo(IFormFile uploadVideo, string path)
        {
            
            string videoName = MyGenerator.GenerateStringUniqCode() + Path.GetExtension(uploadVideo.FileName);

            //upload video  
            string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), path, videoName);
            using (var stream = new FileStream(uploadPath, FileMode.Create))
            {
                uploadVideo.CopyTo(stream);
            }

            return videoName;
        }

        public string UploadFile(IFormFile uploadFile, string path)
        {
            string fileName = MyGenerator.GenerateStringUniqCode() + Path.GetExtension(uploadFile.FileName);

            //upload video  
            string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), path, fileName);
            using (var stream = new FileStream(uploadPath, FileMode.Create))
            {
                uploadFile.CopyTo(stream);
            }

            return fileName;
        }


        public string UploadMusic(IFormFile uploadMusic, string path)
        {
            string musicName = MyGenerator.GenerateStringUniqCode() + Path.GetExtension(uploadMusic.FileName);

            //upload video  
            string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), path, musicName);
            using (var stream = new FileStream(uploadPath, FileMode.Create))
            {
                uploadMusic.CopyTo(stream);
            }
            

            return musicName;
        }

        
        public bool RemovePhoto(string photoName, string path)
        {
            
            var originalPath = Path.Combine(Directory.GetCurrentDirectory(), path, photoName);
            
            if (File.Exists(originalPath))
            {
                try
                {
                    File.Delete(originalPath);
                }
                catch
                {
                    //log
                }
            }

            path = path + "/thumb";
            var thumbPath = Path.Combine(Directory.GetCurrentDirectory(), path, photoName);

            if (File.Exists(thumbPath))
            {
                try
                {
                    File.Delete(thumbPath);
                }
                catch 
                {
                    //log
                }
                
            }
            return true;
        }

        public bool RemoveVideo(string videoName, string path)
        {
            
            var oldPath = Path.Combine(Directory.GetCurrentDirectory(), path, videoName);
            if (File.Exists(oldPath))
            {
                File.Delete(oldPath);
            }
            return true;
        }

        public bool RemoveMusic(string musicName, string path)
        {
            var oldPath = Path.Combine(Directory.GetCurrentDirectory(), path, musicName);
            if (File.Exists(oldPath))
            {
                File.Delete(oldPath);
            }
            return true;
        }

        public bool RemoveFile(string fileName, string path)
        {
            var oldPath = Path.Combine(Directory.GetCurrentDirectory(), path, fileName);
            if (File.Exists(oldPath))
            {
                File.Delete(oldPath);
            }
            return true;
        }
    }
}
