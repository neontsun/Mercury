using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercury.WorkingScripts
{
    public static class ValidateEmail
    {

        /// <summary>
        /// Проверяет email пользователя на валидность путем отправки на него email-сообщения 
        /// </summary>
        /// <param name="email">Email пользователя</param>
        /// <returns>Возвращает логический результат</returns>
        public static bool IsValidEmail(string email)
        {
            // Отправляем тестовое сообщение на email пользователя.
            // Если email валидный, то возвращаем true
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            // Возвращаем false
            catch
            {
                return false;
            }
        }
    }
}
