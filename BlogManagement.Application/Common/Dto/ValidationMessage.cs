namespace BlogManagement.Application.Common.Dto;

public static class ValidationMessage
{
    public const string RequiredMessage = "پر کردن این فیلد اجباری است.";
    public const string MaxFileSizeMessage = "حجم فایل وارد شده بیشتر از حد مجاز است.";
    public const string ExtentionMessage = "فرمت فایل وارد شده مجاز نیست.";
    public const string EmailMessage = "ایمیل وارد شده  مجاز نیست.";
    public const string MaxLengthMessage = "تعداد کارکتر های وارد شده بیش از حد مجاز است.";
    public const string PasswordsNotMatch = "پسورد و تکرار آن با هم مطابقت ندارند";
}