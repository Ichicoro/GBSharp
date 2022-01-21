namespace GBSharp; 

public class CPU {
    const int ClockSpeed = 4194304;

    private byte[] bootloader = new byte[256];
    private byte[] memory = new byte[32768];

    private int rom_bank, ram_bank;

    private byte a = 0x00;
    private byte b = 0x00;
    private byte c = 0x00;
    private byte d = 0x00;
    private byte e = 0x00;
    private byte h = 0x00;
    private byte l = 0x00;

    private uint time = 0;
    private uint enableInterrupts;
    
    bool carry, half_carry, subtract, zero; // flags
    private bool booting;

    private byte joypadState = 0x00;

    private byte f {
        get {
            byte val = 0x0;
            val |= Convert.ToByte((zero ? 0b1 : 0b0) << 0x7);
            val |= Convert.ToByte((subtract ? 0b1 : 0b0) << 0x6);
            val |= Convert.ToByte((half_carry ? 0b1 : 0b0) << 0x5);
            val |= Convert.ToByte((carry ? 0b1 : 0b0) << 0x4);
            return val;
        }
    }

    private byte sp = 0x0000;
    private byte pc = 0x0000;

    public CPU() {
        zero = carry = half_carry = subtract = false;
        pc = 0x0000;
        sp = 0x0000;
        booting = true;
    }

    public void PrintStatus() {
        Console.WriteLine("a = {0}", a);
        Console.WriteLine("f = {0}", f);
        Console.WriteLine("b = {0}", b);
        Console.WriteLine("c = {0}", c);
        Console.WriteLine("d = {0}", d);
        Console.WriteLine("e = {0}", e);
        Console.WriteLine("h = {0}", h);
        Console.WriteLine("l = {0}", l);
        Console.WriteLine("sp = {0}", sp);
        Console.WriteLine("pc = {0}", pc);
        Console.WriteLine("carry = {0}", carry);
        Console.WriteLine("half_carry = {0}", half_carry);
        Console.WriteLine("subtract = {0}", subtract);
        Console.WriteLine("zero = {0}", zero);
    }
}