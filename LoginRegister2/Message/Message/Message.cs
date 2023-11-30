using System.Security.Cryptography;

namespace MessageClass.Message
{
    public static class Message
    {
        public static string UserNotFound = "Kullanıcı Bulunamadı!";
        public static string LoginFailed = "Giriş Başarısız";
        public static string LoginSuccessful = "Giriş Başarılı";
        public static string EmailIncorrect = "E-Mail Hatalı!";
        public static string RegistrationFailed = "Kayıt Olma İşlemi Başarısız";
        public static string RegistrationSuccessful = "Kayıt Olma İşlemi Başarılı";
        public static string OldPasswordIncorrect = "Eski şifre hatalı!";
        public static string PasswordIncorrect = "Hatalı şifre !";
        public static string ValidationError = "Doğrulama Hatası!";
        public static string PasswordChangeError = "Eski şifre ile Yeni şifre aynı olamaz!";
        public static string PasswordChangeFailed = "Şifre değişikliği başarısız!";
        public static string UserAlreadyExists = " Bu kullanıcı zaten mevcut.";
        public static string UserFieldCannotBeEmpty = "Kullanıcı alanı boş bırakılamaz";
        public static string EmailFieldCannotBeEmpty = "Email alanı boş bırakılamaz";
        public static string PasswordFieldCannotBeEmpty = "Şifre alanı boş bırakılamaz";
        public static string USerNameFieldCannotBeEmpty = "Ad-Soyad alanı boş bırakılamaz";
        public static string PasswordControl = "Parolanız en az sekiz karakter, en az bir harf ve bir sayı içermelidir!";


    }
}



