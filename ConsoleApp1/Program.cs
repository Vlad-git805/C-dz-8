using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    interface IRemoveableDisk
    {
        bool HasDisk { get; }

        void Insert();
        void Reject();
    }

    interface IPrintInformation
    {
        string GetName();
        void Print(string str);
    }

    interface IDisk
    {
        string Read();
        void Write(string text);
    }

    class Disk : IDisk
    {
        public string Name { get; set; }
        public string memory { get; set; }
        public int memSize { get; set; }

        public Disk()
        {
            Name = "no name";
            memory = "no memory";
            memSize = 0;
        }

        public Disk(string memory, int memSize, string name)
        {
            Name = name;
            this.memSize = memSize;
            this.memory = memory;
        }

        public virtual string GetName()
        {
            return Name;
        }

        public string Read()
        {
            return memory;
        }

        public void Write(string text)
        {
            memory = text;
        }

        public override string ToString()
        {
            return $"Name: {Name}\n" +
                $"Memory: {memory}\n" +
                $"Memory size: {memSize}";
        }
    }

    class CD : Disk, IRemoveableDisk
    {
        private bool hasDisk;
        public bool HasDisk { get => hasDisk; }

        public override string GetName()
        {
            return base.GetName();
        }

        public void Insert()
        {
            Console.WriteLine("Insert disk");
        }

        public void Reject()
        {
            Console.WriteLine("Reject disk");
        }

        public override string ToString()
        {
            return base.ToString() + "Has disk: " + HasDisk;
        }
    }

    class Falsh : Disk, IRemoveableDisk
    {
        private bool hasDisk;
        public bool HasDisk { get => hasDisk; }

        public override string GetName()
        {
            return base.GetName();
        }

        public void Insert()
        {
            Console.WriteLine("Insert disk");
        }

        public void Reject()
        {
            Console.WriteLine("Reject disk");
        }

        public override string ToString()
        {
            return base.ToString() + "Has disk: " + HasDisk;
        }
    }

    class HDD : Disk
    {
        public override string GetName()
        {
            return base.GetName();
        }
    }

    class DVD : Disk, IRemoveableDisk
    {
        private bool hasDisk;
        public bool HasDisk { get => hasDisk; }

        public override string GetName()
        {
            return base.GetName();
        }

        public void Insert()
        {
            Console.WriteLine("Insert disk");
        }

        public void Reject()
        {
            Console.WriteLine("Reject disk");
        }

        public override string ToString()
        {
            return base.ToString() + "Has disk: " + HasDisk;
        }
    }

    class Comp
    {
        private int countDisk;
        private int countPrintDevice;
        private Disk[] disk;
        private IPrintInformation[] printDevice;

        public void AddDevice(int index, IPrintInformation si)
        {
            IPrintInformation[] printDevice2 = new IPrintInformation[printDevice.Length];
            for (int i = 0; i < printDevice.Length; i++)
            {
                printDevice2[i] = printDevice[i];
            }
            printDevice2[printDevice.Length] = si;
            printDevice = printDevice2;
            countPrintDevice++;
        }

        public void AddDisk(int index, Disk d)
        {
            Disk[] disk2 = new Disk[disk.Length];
            for (int i = 0; i < disk.Length; i++)
            {
                disk2[i] = disk[i];
            }
            disk2[disk.Length] = d;
            disk = disk2;
            countDisk++;
        }

        public bool CheckDisk(string device)
        {
            
            for (int i = 0; i < disk.Length; i++)
            {
                if(disk[i].Name == device)
                {
                    return true;
                }
            }
            return false;
        }

        public Comp(int d, int pb)
        {
            countDisk = d;
            countPrintDevice = pb;
            disk = new Disk[d];
            for (int i = 0; i < d; i++)
            {
                disk[i] = new Disk();
            }
            printDevice = new IPrintInformation[pb];
        }

        public void InsertReject(string device, bool b)
        {
            Console.WriteLine("InsertReject");
        }

        public bool PrintInfo(string text, string device)
        {
            Console.WriteLine(text);
            return true;
        }

        public string ReadInfo(string device)
        {
            return device;
        }

        public void ShowDisk()
        {
            for (int i = 0; i < disk.Length; i++)
            {
                Console.WriteLine(disk[i].ToString());
            }
        }

        public void ShowPrintDevice()
        {
            for (int i = 0; i < printDevice.Length; i++)
            {
                Console.WriteLine(printDevice[i].GetName());
            }
        }

        public bool WriteInfo(string text, string showDevice)
        {
            Console.WriteLine(showDevice);
            return true;
        }

        public override string ToString()
        {
            return $"Count of disks: {countDisk}\n" +
                   $"Count of Print Device: {countPrintDevice}\n";
        }
    }

    class Printer : IPrintInformation
    {
        private string Name { get; set; }

        public string GetName()
        {
            return Name;
        }

        public void Print(string str)
        {
            Console.WriteLine(str);
        }

        public override string ToString()
        {
            return $"Name: {Name}\n";   
        }
    }

    class Monitor : IPrintInformation
    {
        private string Name { get; set; }

        public string GetName()
        {
            return Name;
        }

        public void Print(string str)
        {
            Console.WriteLine(str);
        }

        public override string ToString()
        {
            return $"Name: {Name}\n";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Comp comp = new Comp(2,2);
            comp.ShowDisk();
        }
    }
}
