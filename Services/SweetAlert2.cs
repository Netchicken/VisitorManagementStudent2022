using static VisitorManagementStudent2022.Enum.SweetAlertEnum;

namespace VisitorManagementStudent2022.Services
{
    public class SweetAlert2 : ISweetAlert2
    {


        public string AlertPopupWithImage2(string title, string message, string ImagePath, NotificationType notificationType)
        {
            return "<script type=\"text/javascript\">Swal.fire({ " +
                "title: '" + title + "', " +
                "text: '" + message + "', " +
                "icon: '" + notificationType.ToString() + "', " +
                "imageUrl: '" + ImagePath + "', " +
                "imageWidth: '" + 200 + "', " +
                "imageHeight: '" + 200 + "', " +
                "buttons: false, " +
                "timer: '5000'})</script>";
        }




    }
}
