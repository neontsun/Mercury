using System.Drawing;
using System.Windows.Forms;

namespace Mercury.Animation
{
    public static class Placeholder
    {
        /// <summary>
        /// Создает надпись у объекта класса <see cref="TextBox"/>
        /// </summary>
        /// <param name="tb">Объект класса <see cref="TextBox"/>.</param>
        /// <param name="placeholderText">Текст надписи.</param>
        /// <param name="color">Цвет текста.</param>
        public static void addPlaceholder(TextBox tb, string placeholderText, Color color, Color place)
        {
            // Цвет текста
            tb.ForeColor = place;

            // Текст плейсхолдера
            tb.Text = placeholderText;

            // Событие при получении фокуса
            tb.Enter += (s, e) =>
            {
                if (tb.Text == placeholderText)
                {
                    tb.Text = "";
                }

                tb.ForeColor = color;
            };

            // Событие при потере фокуса
            tb.Leave += (s, e) =>
            {
                if (tb.Text == "")
                {
                    tb.Text = placeholderText;

                    tb.ForeColor = place;
                }
            };
        }
    }
}
