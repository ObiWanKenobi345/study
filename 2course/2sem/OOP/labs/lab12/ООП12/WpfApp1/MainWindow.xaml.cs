using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void CircleDraw_Click(object sender, RoutedEventArgs e)
        {
            Figure circ = new Figure(new AllFactory());
            circ.CircleDrawing();
        }

        private void RectangleDraw_Click(object sender, RoutedEventArgs e)
        {
            Figure rect = new Figure(new AllFactory());
            rect.RectangleDrawing();
        }

        private void Single_Click(object sender, RoutedEventArgs e)
        {
            Line line = new Line();
            line.Launch("12");
            MessageBox.Show(line.dlina.Name, "Single");

            line.Launch("25");
            MessageBox.Show(line.dlina.Name, "Single");

        }

        private void Clone_Click(object sender, RoutedEventArgs e)
        {
            IFigure figure = new Sqard(30, 40);
            IFigure clonedFigure = figure.Clone();
            figure.GetInfo();
            clonedFigure.GetInfo();

            figure = new Ellipse(30);
            clonedFigure = figure.Clone();
            figure.GetInfo();
            clonedFigure.GetInfo();
        }

        private void Builder_Click(object sender, RoutedEventArgs e)
        {
            // содаем объект Художника
            Painter painter = new Painter();
            // создаем билдер 
            CharacterBuilder builder = new RyeCharacterBuilder();
            // рисуем
            Character ryeCharacter = painter.Paint(builder);
            MessageBox.Show(ryeCharacter.ToString(),"ryeCharacter");
            // создаем билдер 
            builder = new WheatCharacterBuilder();
            Character wheatCharacter = painter.Paint(builder);
            MessageBox.Show(wheatCharacter.ToString(), "wheatCharacter");

        }
    }
    //Реализация паттерна Abstract Factory
    abstract class DrawCirc
    {
        public abstract void DrawCircle();
    }
    abstract class DrawRect
    {
        public abstract void DrawRectangle();
    }

    class Circle : DrawCirc
    {
        public override void DrawCircle()
        {
            MessageBox.Show("Нарисован Круг", "Круг");
        }
    }
    class Rectangle : DrawRect
    {
        public override void DrawRectangle()
        {
            MessageBox.Show("Нарисован Прямоугольник", "Прямоугольник");
        }
    }
    abstract class FigureFactory
    {
        public abstract   DrawRect CreateRectangle();
        public abstract DrawCirc CreateCircle();
    }
    class AllFactory : FigureFactory
    {
        public override DrawCirc CreateCircle()
        {
            return new Circle();
        }

        public override DrawRect CreateRectangle()
        {
            return new Rectangle();

        }
    }
    class Figure
    {
        private DrawCirc circle;
        private DrawRect rectangle;
        public Figure(FigureFactory factory)
        {
            circle = factory.CreateCircle();
            rectangle = factory.CreateRectangle();
        }
        public void CircleDrawing()
        {
            circle.DrawCircle();
        }
        public void RectangleDrawing()
        {
            rectangle.DrawRectangle();
        }
    }

    //SIngle
    class Line
    {
        public Dlina dlina { get; set; }
        public void Launch(string osName)
        {
            dlina = Dlina.getInstance(osName);
        }
    }
    class Dlina
    {
        private static Dlina instance;

        public string Name { get; private set; }

        protected Dlina(string name)
        {
            this.Name = name;
        }

        public static Dlina getInstance(string name)
        {
            if (instance == null)
                instance = new Dlina(name);
            return instance;
        }
    }
    //CLone
    interface IFigure
    {
        IFigure Clone();
        void GetInfo();
    }

    class Sqard : IFigure
    {
        int width;
        int height;
        public Sqard(int w, int h)
        {
            width = w;
            height = h;
        }

        public IFigure Clone()
        {
            return new Sqard(this.width, this.height);
        }
        public void GetInfo()
        {
           MessageBox.Show($"Прямоугольник длиной {height} и шириной {width}","Clone quard");
        }
    }

    class Ellipse : IFigure
    {
        int radius;
        public Ellipse(int r)
        {
            radius = r;
        }

        public IFigure Clone()
        {
            return new Ellipse(this.radius);
        }
        public void GetInfo()
        {
            MessageBox.Show($"Круг радиусом {radius}","Clone Ellipse");
        }
    }
    //Реализация паттерна Builder
    //цвет
    class Color
    {
        public string ColorSort { get; set; }
    }
    // Круг вниури
    class InsCircle
    { }
    // Граница
    class Border
    {
        public string Name { get; set; }
    }

    class Character
    {
        // Цвет
        public Color Color { get; set; }
        // Круг Внутри
        public InsCircle InsCircle { get; set; }
        // Граница
        public Border Border { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (Color != null)
                sb.Append(Color.ColorSort + "\n");
            if (InsCircle != null)
                sb.Append("Круг внутри \n");
            if (Border != null)
                sb.Append("Граница: " + Border.Name + " \n");
            return sb.ToString();
        }
    }
    abstract class CharacterBuilder
    {
        public Character Character { get; private set; }
        public void CreateCharacter()
        {
            Character = new Character();
        }
        public abstract void SetColor();
        public abstract void SetInsCircle();
        public abstract void SetBorder();
    }
    // пекарь
    class Painter
    {
        public Character Paint(CharacterBuilder CharacterBuilder)
        {
            CharacterBuilder.CreateCharacter();
            CharacterBuilder.SetColor();
            CharacterBuilder.SetInsCircle();
            CharacterBuilder.SetBorder();
            return CharacterBuilder.Character;
        }
    }
    // строитель для круга крассного
    class RyeCharacterBuilder : CharacterBuilder
    {
        public override void SetColor()
        {
            this.Character.Color = new Color { ColorSort = "крассный" };
        }

        public override void SetInsCircle()
        {
            this.Character.InsCircle = new InsCircle();
        }

        public override void SetBorder()
        {
            // не используется
        }
    }
    // строитель для Желотого круга с красной границей
    class WheatCharacterBuilder : CharacterBuilder
    {
        public override void SetColor()
        {
            this.Character.Color = new Color { ColorSort = "Желтый круг" };
        }

        public override void SetInsCircle()
        {
            this.Character.InsCircle = new InsCircle();
        }

        public override void SetBorder()
        {
            this.Character.Border = new Border { Name = "крассная граница" };
        }
    }
}
