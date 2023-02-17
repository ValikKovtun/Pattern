using System.Runtime.CompilerServices;

namespace Pattern
{
    public partial class Form1 : Form
    {
        public interface ITarget
        {
            string GetRequest();
        }
        class Adaptee
        {
            public string GetSpecificRequest()
            {
                return "����������� ������.";
            }
        }
        class Adapter : ITarget
        {
            private readonly Adaptee _adaptee;

            public Adapter(Adaptee adaptee)
            {
                this._adaptee = adaptee;
            }

            public string GetRequest()
            {
                return $"�� ��� '{this._adaptee.GetSpecificRequest()}'";
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Adaptee adaptee = new Adaptee();
            ITarget target = new Adapter(adaptee);

            label1.Text = "��������� �������� ��������� � �볺����.";
            label2.Text = "��� �� ��������� �������� �볺�� ���� ��������� ���� �����.";

            label3.Text = target.GetRequest();

        }

        public class Person
        {
            public int Age;
            public DateTime BirthDate;
            public string Name;
            public IdInfo IdInfo;

            public Person ShallowCopy()
            {
                return (Person)this.MemberwiseClone();
            }

            public Person DeepCopy()
            {
                Person clone = (Person)this.MemberwiseClone();
                clone.IdInfo = new IdInfo(IdInfo.IdNumber);
                clone.Name = this.Name;
                return clone;
            }
        }

        public class IdInfo
        {
            public int IdNumber;

            public IdInfo(int idNumber)
            {
                this.IdNumber = idNumber;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Person p1 = new Person();
            p1.Age = 24;
            p1.BirthDate = Convert.ToDateTime("1999-01-01");
            p1.Name = "���� ̳�����";
            p1.IdInfo = new IdInfo(111);

            Person p2 = p1.ShallowCopy();
            Person p3 = p1.DeepCopy();

            label1.Text = "�������� �������� p1, p2 �� p3:\np1: ";
            DisplayValues(p1, label1);
            label1.Text += "\np2:";
            DisplayValues(p2, label1);
            label1.Text += "\np3:";
            DisplayValues(p3, label1);


            p1.Age = 23;
            p1.BirthDate = Convert.ToDateTime("2000-01-01");
            p1.Name = "ĳ��";
            p1.IdInfo.IdNumber = 9999;
            label2.Text = "�������� p1 �� p2 ���� ���� p1:\np1: ";
            DisplayValues(p1, label2);
            label2.Text += "\np2:";
            DisplayValues(p2, label2);

            label3.Text = "�������� p1 �� p3:\np1: ";
            DisplayValues(p1, label3);
            label3.Text += "\np3:";
            DisplayValues(p3, label3);
        }

        public static void DisplayValues(Person p, Label label)
        {
            label.Text += "��'�: " + p.Name + ", ³�: " + p.Age + ", ����������: " + p.BirthDate;
            label.Text += "\nID#:" + p.IdInfo.IdNumber;
        }

        public sealed class Singleton
        {
            private Singleton() {}

            private static Singleton _instance;

            public static Singleton GetInstance()
            {
                if (_instance == null)
                {
                    _instance = new Singleton();
                }
                return _instance;
            }

            // ����� ��� �� ���� �������� � ����� ��������
            public void someBusinessLogic()
            {
                //...
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Singleton s1 = Singleton.GetInstance();
            Singleton s2 = Singleton.GetInstance();

            if (s1 == s2)
                label1.Text = "�������� ������, ����� ���� ������ ���� ���������.";
            else
                label1.Text = "�������� �� ������, ����� ���� ������ ��� ���������.";
            label2.Text = label3.Text = " ";
        }
    }
}
