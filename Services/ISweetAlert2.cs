using VisitorManagementStudent2022.Enum;

namespace VisitorManagementStudent2022.Services
{
    public interface ISweetAlert2
    {
        string AlertPopupWithImage2(string title, string message, string ImagePath, SweetAlertEnum.NotificationType notificationType);
    }
}