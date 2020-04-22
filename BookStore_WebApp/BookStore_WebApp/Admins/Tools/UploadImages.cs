using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace BookStore.WebApp.Tools
{
    public class UploadImages : System.Web.UI.Page
    {
        /// <summary>
        /// 上传文件方法
        /// </summary>
        /// <param name="f">上传控件对象</param>
        /// <param name="url">上传文件所到的位置</param>
        /// <returns>上传之后的文件名称</returns>
        public string UpFileName(FileUpload f,string url)
        {
            //202004211525032394.jpg
            Random r = new Random();
            string res = ""; //用于记录文件最后的名称
            string filePath = f.FileName;
            string newName = DateTime.Now.ToString("yyyyMMddHHmmss") + r.Next(1, 9999);

            if (filePath != "")
            {
                string fileType = filePath.Substring(filePath.LastIndexOf('.')); //.jpg 
                string filePic = Server.MapPath(url + newName + fileType);
                f.PostedFile.SaveAs(filePic);
                res = newName + fileType;
            }

            return res;

        }
    }
}