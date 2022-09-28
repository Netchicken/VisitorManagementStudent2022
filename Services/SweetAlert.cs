using static VisitorManagementStudent2022.Enum.SweetAlertEnum;

namespace VisitorManagementStudent2022.Services
{
    public class SweetAlert : ISweetAlert, ISweetAlert2
    {
        /// <summary>
        /// SweetAlert popups  https://sweetalert2.github.io/#download https://sweetalert2.github.io/#input-types
        /// </summary>

        public string AlertPopup(string title, string message, NotificationType notificationType)
        {
            return "<script type=\"text/javascript\">Swal.fire({ " +
                "title: '" + title + "', " +
                "text: '" + message + "', " +
                "icon: '" + notificationType.ToString() + "', " +
                "buttons: false, " +
                "timer: '10000'})</script>";
        }
        public string AlertCancel(string title, string message, string buttonText, NotificationType notificationType)
        {
            return "<script type=\"text/javascript\">Swal.fire({ " +
                "title: '" + title + "', " +
                "text: '" + message + "', " +
                "icon: '" + notificationType.ToString() + "', " +
                "button: '" + buttonText + "', " +
                "timer: '5000'})</script>";
        }

        public string AlertPopupWithImage(string title, string message, string ImagePath, NotificationType notificationType)
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


        public string AlertPopupNoNotif(string title, string message)
        {
            return "<script type=\"text/javascript\">Swal.fire({ " +
                "title: '" + title + "', " +
                "text: '" + message + "', " +
                "timer: '10000'})</script>";
        }



    }
}
