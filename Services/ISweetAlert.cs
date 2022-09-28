using VisitorManagementStudent2022.Enum;

namespace VisitorManagementStudent2022.Services
{
    public interface ISweetAlert
    {
        string AlertCancel(string title, string message, string buttonText, SweetAlertEnum.NotificationType notificationType);
        string AlertPopup(string title, string message, SweetAlertEnum.NotificationType notificationType);
        string AlertPopupWithImage(string title, string message, string ImagePath, SweetAlertEnum.NotificationType notificationType);
        string AlertPopupNoNotif(string title, string message);
    }
}