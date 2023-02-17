using System.Runtime.CompilerServices;

namespace BrainfuckInterpreter
{
	public partial class Form1 : Form
	{
		private static Memory _memory = Memory.Instance;
		private Interpreter _interpreter = new Interpreter();
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			new MemoryObserver(_memory, (value) =>
			{
				if (value.Type == MemoryEventType.INCREASE_POINTER)
				{
					
				}
				if (value.Type == MemoryEventType.DECREASE_POINTER)
				{
					
				}
				if (value.Type == MemoryEventType.INCREASE_VALUE)
				{
					
				}
				if (value.Type == MemoryEventType.DECREASE_VALUE)
				{
					
				}
				if (value.Type == MemoryEventType.OUT)
				{
					foreach(byte b in Memory.Instance.GetBytes())
					{
						if (b != 0)
						{
							this.richTextBox2.Text += (char)b;
						}
					}
				}
			});
		}

		private void button1_Click(object sender, EventArgs e)
		{
			_interpreter.Compile(richTextBox1.Text);
		}

		private void richTextBox1_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
