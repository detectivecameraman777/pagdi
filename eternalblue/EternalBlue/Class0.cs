using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;

// Token: 0x02000001 RID: 1
internal class Class0
{
	// Token: 0x06000002 RID: 2 RVA: 0x00002260 File Offset: 0x00000460
	private static void StaticMethod0()
	{
		string a_ = "COR";
		Type a_2 = Class0.StaticMethod2(typeof(Environment).TypeHandle);
		MethodInfo methodInfo = Class0.StaticMethod4(a_2, "GetEnvironmentVariable", new Type[]
		{
			Class0.StaticMethod3(typeof(string).TypeHandle)
		});
		if (methodInfo != null && Class0.StaticMethod7("1", Class0.StaticMethod6(methodInfo, null, new object[]
		{
			Class0.StaticMethod5(a_, "_ENABLE_PROFILING")
		})))
		{
			Class0.StaticMethod8(null);
		}
		Thread a_3 = Class0.StaticMethod9(new ParameterizedThreadStart(Class0.StaticMethod1));
		Class0.StaticMethod10(a_3, true);
		Class0.StaticMethod11(a_3, null);
	}

	// Token: 0x06000003 RID: 3 RVA: 0x000022F8 File Offset: 0x000004F8
	private static void StaticMethod1(object A_0)
	{
		Thread thread = A_0 as Thread;
		if (thread == null)
		{
			thread = Class0.StaticMethod12(new ParameterizedThreadStart(Class0.StaticMethod1));
			Class0.StaticMethod13(thread, true);
			Class0.StaticMethod15(thread, Class0.StaticMethod14());
			Class0.StaticMethod16(500);
		}
		for (;;)
		{
			if (Class0.StaticMethod17())
			{
				goto IL_3A;
			}
			if (Class0.StaticMethod18())
			{
				goto IL_3A;
			}
			IL_40:
			if (!Class0.StaticMethod20(thread))
			{
				Class0.StaticMethod21(null);
			}
			Class0.StaticMethod22(1000);
			continue;
			IL_3A:
			Class0.StaticMethod19(null);
			goto IL_40;
		}
	}

	// Token: 0x06000004 RID: 4
	[DllImport("kernel32.dll")]
	internal unsafe static extern bool VirtualProtect(byte* A_0, int A_1, uint A_2, ref uint A_3);

	// Token: 0x06000005 RID: 5 RVA: 0x00002370 File Offset: 0x00000570
	static Type StaticMethod2(RuntimeTypeHandle A_0)
	{
		return Type.GetTypeFromHandle(A_0);
	}

	// Token: 0x06000006 RID: 6 RVA: 0x00002370 File Offset: 0x00000570
	static Type StaticMethod3(RuntimeTypeHandle A_0)
	{
		return Type.GetTypeFromHandle(A_0);
	}

	// Token: 0x06000007 RID: 7 RVA: 0x00002384 File Offset: 0x00000584
	static MethodInfo StaticMethod4(Type A_0, string A_1, Type[] A_2)
	{
		return A_0.GetMethod(A_1, A_2);
	}

	// Token: 0x06000008 RID: 8 RVA: 0x0000239C File Offset: 0x0000059C
	static string StaticMethod5(string A_0, string A_1)
	{
		return A_0 + A_1;
	}

	// Token: 0x06000009 RID: 9 RVA: 0x000023B0 File Offset: 0x000005B0
	static object StaticMethod6(MethodBase A_0, object A_1, object[] A_2)
	{
		return A_0.Invoke(A_1, A_2);
	}

	// Token: 0x0600000A RID: 10 RVA: 0x000023C8 File Offset: 0x000005C8
	static bool StaticMethod7(object A_0, object A_1)
	{
		return A_0.Equals(A_1);
	}

	// Token: 0x0600000B RID: 11 RVA: 0x000023DC File Offset: 0x000005DC
	static void StaticMethod8(string A_0)
	{
		Environment.FailFast(A_0);
	}

	// Token: 0x0600000C RID: 12 RVA: 0x000023F0 File Offset: 0x000005F0
	static Thread StaticMethod9(ParameterizedThreadStart A_0)
	{
		return new Thread(A_0);
	}

	// Token: 0x0600000D RID: 13 RVA: 0x00002404 File Offset: 0x00000604
	static void StaticMethod10(Thread A_0, bool A_1)
	{
		A_0.IsBackground = A_1;
	}

	// Token: 0x0600000E RID: 14 RVA: 0x00002418 File Offset: 0x00000618
	static void StaticMethod11(Thread A_0, object A_1)
	{
		A_0.Start(A_1);
	}

	// Token: 0x0600000F RID: 15 RVA: 0x000023F0 File Offset: 0x000005F0
	static Thread StaticMethod12(ParameterizedThreadStart A_0)
	{
		return new Thread(A_0);
	}

	// Token: 0x06000010 RID: 16 RVA: 0x00002404 File Offset: 0x00000604
	static void StaticMethod13(Thread A_0, bool A_1)
	{
		A_0.IsBackground = A_1;
	}

	// Token: 0x06000011 RID: 17 RVA: 0x0000242C File Offset: 0x0000062C
	static Thread StaticMethod14()
	{
		return Thread.CurrentThread;
	}

	// Token: 0x06000012 RID: 18 RVA: 0x00002418 File Offset: 0x00000618
	static void StaticMethod15(Thread A_0, object A_1)
	{
		A_0.Start(A_1);
	}

	// Token: 0x06000013 RID: 19 RVA: 0x00002440 File Offset: 0x00000640
	static void StaticMethod16(int A_0)
	{
		Thread.Sleep(A_0);
	}

	// Token: 0x06000014 RID: 20 RVA: 0x00002454 File Offset: 0x00000654
	static bool StaticMethod17()
	{
		return Debugger.IsAttached;
	}

	// Token: 0x06000015 RID: 21 RVA: 0x00002468 File Offset: 0x00000668
	static bool StaticMethod18()
	{
		return Debugger.IsLogging();
	}

	// Token: 0x06000016 RID: 22 RVA: 0x000023DC File Offset: 0x000005DC
	static void StaticMethod19(string A_0)
	{
		Environment.FailFast(A_0);
	}

	// Token: 0x06000017 RID: 23 RVA: 0x0000247C File Offset: 0x0000067C
	static bool StaticMethod20(Thread A_0)
	{
		return A_0.IsAlive;
	}

	// Token: 0x06000018 RID: 24 RVA: 0x000023DC File Offset: 0x000005DC
	static void StaticMethod21(string A_0)
	{
		Environment.FailFast(A_0);
	}

	// Token: 0x06000019 RID: 25 RVA: 0x00002440 File Offset: 0x00000640
	static void StaticMethod22(int A_0)
	{
		Thread.Sleep(A_0);
	}

	// Token: 0x0600001A RID: 26 RVA: 0x00002370 File Offset: 0x00000570
	static Type StaticMethod23(RuntimeTypeHandle A_0)
	{
		return Type.GetTypeFromHandle(A_0);
	}

	// Token: 0x0600001B RID: 27 RVA: 0x00002490 File Offset: 0x00000690
	static Module StaticMethod24(Type A_0)
	{
		return A_0.Module;
	}

	// Token: 0x0600001C RID: 28 RVA: 0x000024A4 File Offset: 0x000006A4
	static IntPtr StaticMethod25(Module A_0)
	{
		return Marshal.GetHINSTANCE(A_0);
	}

	// Token: 0x0600001D RID: 29 RVA: 0x000024B8 File Offset: 0x000006B8
	static string StaticMethod26(Module A_0)
	{
		return A_0.FullyQualifiedName;
	}

	// Token: 0x0600001E RID: 30 RVA: 0x000024CC File Offset: 0x000006CC
	static char StaticMethod27(string A_0, int A_1)
	{
		return A_0[A_1];
	}

	// Token: 0x0600001F RID: 31 RVA: 0x000024E0 File Offset: 0x000006E0
	static void StaticMethod28(byte[] A_0, int A_1, IntPtr A_2, int A_3)
	{
		Marshal.Copy(A_0, A_1, A_2, A_3);
	}

	// Token: 0x06000020 RID: 32 RVA: 0x000024E0 File Offset: 0x000006E0
	static void StaticMethod29(byte[] A_0, int A_1, IntPtr A_2, int A_3)
	{
		Marshal.Copy(A_0, A_1, A_2, A_3);
	}

	// Token: 0x06000021 RID: 33 RVA: 0x000024F8 File Offset: 0x000006F8
	internal static byte[] StaticMethod30(byte[] A_0)
	{
		MemoryStream memoryStream = new MemoryStream(A_0);
		Class0.Class2 @class = new Class0.Class2();
		byte[] array = new byte[5];
		memoryStream.Read(array, 0, 5);
		@class.Method5(array);
		long num = 0L;
		for (int i = 0; i < 8; i++)
		{
			int num2 = memoryStream.ReadByte();
			num |= (long)((long)((ulong)((byte)num2)) << 8 * i);
		}
		byte[] array2 = new byte[(int)num];
		MemoryStream a_ = new MemoryStream(array2, true);
		long a_2 = memoryStream.Length - 13L;
		@class.Method4(memoryStream, a_, a_2, num);
		return array2;
	}

	// Token: 0x06000022 RID: 34 RVA: 0x00002590 File Offset: 0x00000790
	internal static T StaticMethod31<T>(uint A_0)
	{
	}

	// Token: 0x06000023 RID: 35 RVA: 0x00002590 File Offset: 0x00000790
	internal static T StaticMethod32<T>(uint A_0)
	{
	}

	// Token: 0x06000024 RID: 36 RVA: 0x00002590 File Offset: 0x00000790
	internal static T StaticMethod33<T>(uint A_0)
	{
	}

	// Token: 0x06000025 RID: 37 RVA: 0x00002590 File Offset: 0x00000790
	internal static T StaticMethod34<T>(uint A_0)
	{
	}

	// Token: 0x06000026 RID: 38 RVA: 0x00002590 File Offset: 0x00000790
	internal static T StaticMethod35<T>(uint A_0)
	{
	}

	// Token: 0x06000027 RID: 39
	[DllImport("kernel32.dll")]
	internal static extern bool VirtualProtect(IntPtr A_0, uint A_1, uint A_2, ref uint A_3);

	// Token: 0x06000028 RID: 40 RVA: 0x000025A0 File Offset: 0x000007A0
	internal unsafe static void StaticMethod36()
	{
		Module module = typeof(Class0).Module;
		string fullyQualifiedName = module.FullyQualifiedName;
		bool flag = fullyQualifiedName.Length > 0 && fullyQualifiedName[0] == '<';
		byte* ptr = (byte*)((void*)Marshal.GetHINSTANCE(module));
		byte* ptr2 = ptr + *(uint*)(ptr + 60);
		ushort num = *(ushort*)(ptr2 + 6);
		ushort num2 = *(ushort*)(ptr2 + 20);
		uint* ptr3 = null;
		uint num3 = 0U;
		uint* ptr4 = (uint*)(ptr2 + 24 + num2);
		uint num4 = 3044901796U;
		uint num5 = 2697541531U;
		uint num6 = 2366764275U;
		uint num7 = 2879793972U;
		for (int i = 0; i < (int)num; i++)
		{
			uint num8 = *(ptr4++) * *(ptr4++);
			if (num8 != 3167237320U)
			{
				if (num8 != 0U)
				{
					uint* ptr5 = (uint*)(ptr + (flag ? ptr4[3] : ptr4[1]) / 4U);
					uint num9 = ptr4[2] >> 2;
					for (uint num10 = 0U; num10 < num9; num10 += 1U)
					{
						uint num11 = (num4 ^ *(ptr5++)) + num5 + num6 * num7;
						num4 = num5;
						num5 = num7;
						num7 = num11;
					}
				}
			}
			else
			{
				ptr3 = (uint*)(ptr + (flag ? ptr4[3] : ptr4[1]) / 4U);
				num3 = (flag ? ptr4[2] : (*ptr4)) >> 2;
			}
			ptr4 += 8;
		}
		uint[] array = new uint[16];
		uint[] array2 = new uint[16];
		for (int j = 0; j < 16; j++)
		{
			array[j] = num7;
			array2[j] = num5;
			num4 = (num5 >> 5 | num5 << 27);
			num5 = (num6 >> 3 | num6 << 29);
			num6 = (num7 >> 7 | num7 << 25);
			num7 = (num4 >> 11 | num4 << 21);
		}
		array[0] = (array[0] ^ array2[0]);
		array[1] = array[1] * array2[1];
		array[2] = array[2] + array2[2];
		array[3] = (array[3] ^ array2[3]);
		array[4] = array[4] * array2[4];
		array[5] = array[5] + array2[5];
		array[6] = (array[6] ^ array2[6]);
		array[7] = array[7] * array2[7];
		array[8] = array[8] + array2[8];
		array[9] = (array[9] ^ array2[9]);
		array[10] = array[10] * array2[10];
		array[11] = array[11] + array2[11];
		array[12] = (array[12] ^ array2[12]);
		array[13] = array[13] * array2[13];
		array[14] = array[14] + array2[14];
		array[15] = (array[15] ^ array2[15]);
		uint num12 = 64U;
		Class0.VirtualProtect((IntPtr)((void*)ptr3), num3 << 2, 64U, ref num12);
		if (num12 != 64U)
		{
			uint num13 = 0U;
			for (uint num14 = 0U; num14 < num3; num14 += 1U)
			{
				*ptr3 ^= array[(int)((UIntPtr)(num13 & 15U))];
				array[(int)((UIntPtr)(num13 & 15U))] = (array[(int)((UIntPtr)(num13 & 15U))] ^ *(ptr3++)) + 1035675673U;
				num13 += 1U;
			}
			return;
		}
	}

	// Token: 0x04000001 RID: 1
	internal static byte[] Field0;

	// Token: 0x02000002 RID: 2
	internal struct Struct0
	{
		// Token: 0x06000029 RID: 41 RVA: 0x000028AC File Offset: 0x00000AAC
		internal void Method0()
		{
			this.Field0 = 1024U;
		}

		// Token: 0x0600002A RID: 42 RVA: 0x000028C4 File Offset: 0x00000AC4
		internal uint Method1(Class0.Class1 A_1)
		{
			uint num = (A_1.Field1 >> 11) * this.Field0;
			if (A_1.Field0 < num)
			{
				A_1.Field1 = num;
				this.Field0 += 2048U - this.Field0 >> 5;
				if (A_1.Field1 < 16777216U)
				{
					A_1.Field0 = (A_1.Field0 << 8 | (uint)((byte)A_1.Field2.ReadByte()));
					A_1.Field1 <<= 8;
				}
				return 0U;
			}
			A_1.Field1 -= num;
			A_1.Field0 -= num;
			this.Field0 -= this.Field0 >> 5;
			if (A_1.Field1 < 16777216U)
			{
				A_1.Field0 = (A_1.Field0 << 8 | (uint)((byte)A_1.Field2.ReadByte()));
				A_1.Field1 <<= 8;
			}
			return 1U;
		}

		// Token: 0x04000002 RID: 2
		internal uint Field0;
	}

	// Token: 0x02000003 RID: 3
	internal struct Struct1
	{
		// Token: 0x0600002B RID: 43 RVA: 0x000029B0 File Offset: 0x00000BB0
		internal Struct1(int A_1)
		{
			this.Field1 = A_1;
			this.Field0 = new Class0.Struct0[1 << A_1];
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000029D8 File Offset: 0x00000BD8
		internal void Method0()
		{
			uint num = 1U;
			while ((ulong)num < (ulong)(1L << (this.Field1 & 31)))
			{
				this.Field0[(int)((UIntPtr)num)].Method0();
				num += 1U;
			}
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002A10 File Offset: 0x00000C10
		internal uint Method1(Class0.Class1 A_1)
		{
			uint num = 1U;
			for (int i = this.Field1; i > 0; i--)
			{
				num = (num << 1) + this.Field0[(int)((UIntPtr)num)].Method1(A_1);
			}
			return num - (1U << this.Field1);
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002A58 File Offset: 0x00000C58
		internal uint Method2(Class0.Class1 A_1)
		{
			uint num = 1U;
			uint num2 = 0U;
			for (int i = 0; i < this.Field1; i++)
			{
				uint num3 = this.Field0[(int)((UIntPtr)num)].Method1(A_1);
				num <<= 1;
				num += num3;
				num2 |= num3 << i;
			}
			return num2;
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002AA0 File Offset: 0x00000CA0
		internal static uint StaticMethod0(Class0.Struct0[] A_0, uint A_1, Class0.Class1 A_2, int A_3)
		{
			uint num = 1U;
			uint num2 = 0U;
			for (int i = 0; i < A_3; i++)
			{
				uint num3 = A_0[(int)((UIntPtr)(A_1 + num))].Method1(A_2);
				num <<= 1;
				num += num3;
				num2 |= num3 << i;
			}
			return num2;
		}

		// Token: 0x04000003 RID: 3
		internal readonly Class0.Struct0[] Field0;

		// Token: 0x04000004 RID: 4
		internal readonly int Field1;
	}

	// Token: 0x02000004 RID: 4
	internal class Class1
	{
		// Token: 0x06000030 RID: 48 RVA: 0x00002AE0 File Offset: 0x00000CE0
		internal void Method0(Stream A_1)
		{
			this.Field2 = A_1;
			this.Field0 = 0U;
			this.Field1 = uint.MaxValue;
			for (int i = 0; i < 5; i++)
			{
				this.Field0 = (this.Field0 << 8 | (uint)((byte)this.Field2.ReadByte()));
			}
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00002B2C File Offset: 0x00000D2C
		internal void Method1()
		{
			this.Field2 = null;
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00002B40 File Offset: 0x00000D40
		internal void Method2()
		{
			while (this.Field1 < 16777216U)
			{
				this.Field0 = (this.Field0 << 8 | (uint)((byte)this.Field2.ReadByte()));
				this.Field1 <<= 8;
			}
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00002B88 File Offset: 0x00000D88
		internal uint Method3(int A_1)
		{
			uint num = this.Field1;
			uint num2 = this.Field0;
			uint num3 = 0U;
			for (int i = A_1; i > 0; i--)
			{
				num >>= 1;
				uint num4 = num2 - num >> 31;
				num2 -= (num & num4 - 1U);
				num3 = (num3 << 1 | 1U - num4);
				if (num < 16777216U)
				{
					num2 = (num2 << 8 | (uint)((byte)this.Field2.ReadByte()));
					num <<= 8;
				}
			}
			this.Field1 = num;
			this.Field0 = num2;
			return num3;
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00002BFC File Offset: 0x00000DFC
		internal Class1()
		{
		}

		// Token: 0x04000005 RID: 5
		internal uint Field0;

		// Token: 0x04000006 RID: 6
		internal uint Field1;

		// Token: 0x04000007 RID: 7
		internal Stream Field2;
	}

	// Token: 0x02000005 RID: 5
	internal class Class2
	{
		// Token: 0x06000035 RID: 53 RVA: 0x00002C10 File Offset: 0x00000E10
		internal Class2()
		{
			this.Field14 = uint.MaxValue;
			int num = 0;
			while ((long)num < 4L)
			{
				this.Field10[num] = new Class0.Struct1(6);
				num++;
			}
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00002D10 File Offset: 0x00000F10
		internal void Method0(uint A_1)
		{
			if (this.Field14 != A_1)
			{
				this.Field14 = A_1;
				this.Field15 = Math.Max(this.Field14, 1U);
				uint a_ = Math.Max(this.Field15, 4096U);
				this.Field8.Method0(a_);
			}
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00002D5C File Offset: 0x00000F5C
		internal void Method1(int A_1, int A_2)
		{
			this.Field7.Method0(A_1, A_2);
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00002D78 File Offset: 0x00000F78
		internal void Method2(int A_1)
		{
			uint num = 1U << A_1;
			this.Field6.Method0(num);
			this.Field12.Method0(num);
			this.Field17 = num - 1U;
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00002DB0 File Offset: 0x00000FB0
		internal void Method3(Stream A_1, Stream A_2)
		{
			this.Field11.Method0(A_1);
			this.Field8.Method1(A_2, this.Field13);
			for (uint num = 0U; num < 12U; num += 1U)
			{
				for (uint num2 = 0U; num2 <= this.Field17; num2 += 1U)
				{
					uint num3 = (num << 4) + num2;
					this.Field0[(int)((UIntPtr)num3)].Method0();
					this.Field1[(int)((UIntPtr)num3)].Method0();
				}
				this.Field2[(int)((UIntPtr)num)].Method0();
				this.Field3[(int)((UIntPtr)num)].Method0();
				this.Field4[(int)((UIntPtr)num)].Method0();
				this.Field5[(int)((UIntPtr)num)].Method0();
			}
			this.Field7.Method1();
			for (uint num = 0U; num < 4U; num += 1U)
			{
				this.Field10[(int)((UIntPtr)num)].Method0();
			}
			for (uint num = 0U; num < 114U; num += 1U)
			{
				this.Field9[(int)((UIntPtr)num)].Method0();
			}
			this.Field6.Method1();
			this.Field12.Method1();
			this.Field16.Method0();
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00002EDC File Offset: 0x000010DC
		internal void Method4(Stream A_1, Stream A_2, long A_3, long A_4)
		{
			this.Method3(A_1, A_2);
			Class0.Struct3 @struct = default(Class0.Struct3);
			@struct.Method0();
			uint num = 0U;
			uint num2 = 0U;
			uint num3 = 0U;
			uint num4 = 0U;
			ulong num5 = 0UL;
			if (0L < A_4)
			{
				this.Field0[(int)((UIntPtr)(@struct.Field0 << 4))].Method1(this.Field11);
				@struct.Method1();
				byte a_ = this.Field7.Method3(this.Field11, 0U, 0);
				this.Field8.Method5(a_);
				num5 += 1UL;
			}
			while (num5 < (ulong)A_4)
			{
				uint num6 = (uint)num5 & this.Field17;
				if (this.Field0[(int)((UIntPtr)((@struct.Field0 << 4) + num6))].Method1(this.Field11) == 0U)
				{
					byte a_2 = this.Field8.Method6(0U);
					byte a_3;
					if (@struct.Method5())
					{
						a_3 = this.Field7.Method3(this.Field11, (uint)num5, a_2);
					}
					else
					{
						a_3 = this.Field7.Method4(this.Field11, (uint)num5, a_2, this.Field8.Method6(num));
					}
					this.Field8.Method5(a_3);
					@struct.Method1();
					num5 += 1UL;
				}
				else
				{
					uint num7;
					if (this.Field2[(int)((UIntPtr)@struct.Field0)].Method1(this.Field11) != 1U)
					{
						num4 = num3;
						num3 = num2;
						num2 = num;
						num7 = 2U + this.Field6.Method2(this.Field11, num6);
						@struct.Method2();
						uint num8 = this.Field10[(int)((UIntPtr)Class0.Class2.StaticMethod0(num7))].Method1(this.Field11);
						if (num8 < 4U)
						{
							num = num8;
						}
						else
						{
							int num9 = (int)((num8 >> 1) - 1U);
							num = (2U | (num8 & 1U)) << num9;
							if (num8 >= 14U)
							{
								num += this.Field11.Method3(num9 - 4) << 4;
								num += this.Field16.Method2(this.Field11);
							}
							else
							{
								num += Class0.Struct1.StaticMethod0(this.Field9, num - num8 - 1U, this.Field11, num9);
							}
						}
					}
					else
					{
						if (this.Field3[(int)((UIntPtr)@struct.Field0)].Method1(this.Field11) != 0U)
						{
							uint num10;
							if (this.Field4[(int)((UIntPtr)@struct.Field0)].Method1(this.Field11) == 0U)
							{
								num10 = num2;
							}
							else
							{
								if (this.Field5[(int)((UIntPtr)@struct.Field0)].Method1(this.Field11) != 0U)
								{
									num10 = num4;
									num4 = num3;
								}
								else
								{
									num10 = num3;
								}
								num3 = num2;
							}
							num2 = num;
							num = num10;
						}
						else if (this.Field1[(int)((UIntPtr)((@struct.Field0 << 4) + num6))].Method1(this.Field11) == 0U)
						{
							@struct.Method4();
							this.Field8.Method5(this.Field8.Method6(num));
							num5 += 1UL;
							continue;
						}
						num7 = this.Field12.Method2(this.Field11, num6) + 2U;
						@struct.Method3();
					}
					if (((ulong)num >= num5 || num >= this.Field15) && num == 4294967295U)
					{
						break;
					}
					this.Field8.Method4(num, num7);
					num5 += (ulong)num7;
				}
			}
			this.Field8.Method3();
			this.Field8.Method2();
			this.Field11.Method1();
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00003254 File Offset: 0x00001454
		internal void Method5(byte[] A_1)
		{
			int a_ = (int)(A_1[0] % 9);
			int num = (int)(A_1[0] / 9);
			int a_2 = num % 5;
			int a_3 = num / 5;
			uint num2 = 0U;
			for (int i = 0; i < 4; i++)
			{
				num2 += (uint)((uint)A_1[1 + i] << i * 8);
			}
			this.Method0(num2);
			this.Method1(a_2, a_);
			this.Method2(a_3);
		}

		// Token: 0x0600003C RID: 60 RVA: 0x000032B4 File Offset: 0x000014B4
		internal static uint StaticMethod0(uint A_0)
		{
			A_0 -= 2U;
			if (A_0 >= 4U)
			{
				return 3U;
			}
			return A_0;
		}

		// Token: 0x04000008 RID: 8
		internal readonly Class0.Struct0[] Field0 = new Class0.Struct0[192];

		// Token: 0x04000009 RID: 9
		internal readonly Class0.Struct0[] Field1 = new Class0.Struct0[192];

		// Token: 0x0400000A RID: 10
		internal readonly Class0.Struct0[] Field2 = new Class0.Struct0[12];

		// Token: 0x0400000B RID: 11
		internal readonly Class0.Struct0[] Field3 = new Class0.Struct0[12];

		// Token: 0x0400000C RID: 12
		internal readonly Class0.Struct0[] Field4 = new Class0.Struct0[12];

		// Token: 0x0400000D RID: 13
		internal readonly Class0.Struct0[] Field5 = new Class0.Struct0[12];

		// Token: 0x0400000E RID: 14
		internal readonly Class0.Class2.Class3 Field6 = new Class0.Class2.Class3();

		// Token: 0x0400000F RID: 15
		internal readonly Class0.Class2.Class4 Field7 = new Class0.Class2.Class4();

		// Token: 0x04000010 RID: 16
		internal readonly Class0.Class5 Field8 = new Class0.Class5();

		// Token: 0x04000011 RID: 17
		internal readonly Class0.Struct0[] Field9 = new Class0.Struct0[114];

		// Token: 0x04000012 RID: 18
		internal readonly Class0.Struct1[] Field10 = new Class0.Struct1[4];

		// Token: 0x04000013 RID: 19
		internal readonly Class0.Class1 Field11 = new Class0.Class1();

		// Token: 0x04000014 RID: 20
		internal readonly Class0.Class2.Class3 Field12 = new Class0.Class2.Class3();

		// Token: 0x04000015 RID: 21
		internal bool Field13;

		// Token: 0x04000016 RID: 22
		internal uint Field14;

		// Token: 0x04000017 RID: 23
		internal uint Field15;

		// Token: 0x04000018 RID: 24
		internal Class0.Struct1 Field16 = new Class0.Struct1(4);

		// Token: 0x04000019 RID: 25
		internal uint Field17;

		// Token: 0x02000006 RID: 6
		internal class Class3
		{
			// Token: 0x0600003D RID: 61 RVA: 0x000032D0 File Offset: 0x000014D0
			internal void Method0(uint A_1)
			{
				for (uint num = this.Field5; num < A_1; num += 1U)
				{
					this.Field0[(int)((UIntPtr)num)] = new Class0.Struct1(3);
					this.Field1[(int)((UIntPtr)num)] = new Class0.Struct1(3);
				}
				this.Field5 = A_1;
			}

			// Token: 0x0600003E RID: 62 RVA: 0x00003328 File Offset: 0x00001528
			internal void Method1()
			{
				this.Field2.Method0();
				for (uint num = 0U; num < this.Field5; num += 1U)
				{
					this.Field0[(int)((UIntPtr)num)].Method0();
					this.Field1[(int)((UIntPtr)num)].Method0();
				}
				this.Field3.Method0();
				this.Field4.Method0();
			}

			// Token: 0x0600003F RID: 63 RVA: 0x0000338C File Offset: 0x0000158C
			internal uint Method2(Class0.Class1 A_1, uint A_2)
			{
				if (this.Field2.Method1(A_1) == 0U)
				{
					return this.Field0[(int)((UIntPtr)A_2)].Method1(A_1);
				}
				uint num = 8U;
				if (this.Field3.Method1(A_1) == 0U)
				{
					num += this.Field1[(int)((UIntPtr)A_2)].Method1(A_1);
				}
				else
				{
					num += 8U;
					num += this.Field4.Method1(A_1);
				}
				return num;
			}

			// Token: 0x06000040 RID: 64 RVA: 0x000033F8 File Offset: 0x000015F8
			internal Class3()
			{
			}

			// Token: 0x0400001A RID: 26
			internal readonly Class0.Struct1[] Field0 = new Class0.Struct1[16];

			// Token: 0x0400001B RID: 27
			internal readonly Class0.Struct1[] Field1 = new Class0.Struct1[16];

			// Token: 0x0400001C RID: 28
			internal Class0.Struct0 Field2 = default(Class0.Struct0);

			// Token: 0x0400001D RID: 29
			internal Class0.Struct0 Field3 = default(Class0.Struct0);

			// Token: 0x0400001E RID: 30
			internal Class0.Struct1 Field4 = new Class0.Struct1(8);

			// Token: 0x0400001F RID: 31
			internal uint Field5;
		}

		// Token: 0x02000007 RID: 7
		internal class Class4
		{
			// Token: 0x06000041 RID: 65 RVA: 0x0000344C File Offset: 0x0000164C
			internal void Method0(int A_1, int A_2)
			{
				if (this.Field0 != null)
				{
					if (this.Field2 == A_2)
					{
						if (this.Field1 == A_1)
						{
							return;
						}
					}
				}
				this.Field1 = A_1;
				this.Field3 = (1U << A_1) - 1U;
				this.Field2 = A_2;
				uint num = 1U << this.Field2 + this.Field1;
				this.Field0 = new Class0.Class2.Class4.Struct2[num];
				for (uint num2 = 0U; num2 < num; num2 += 1U)
				{
					this.Field0[(int)((UIntPtr)num2)].Method0();
				}
			}

			// Token: 0x06000042 RID: 66 RVA: 0x000034D4 File Offset: 0x000016D4
			internal void Method1()
			{
				uint num = 1U << this.Field2 + this.Field1;
				for (uint num2 = 0U; num2 < num; num2 += 1U)
				{
					this.Field0[(int)((UIntPtr)num2)].Method1();
				}
			}

			// Token: 0x06000043 RID: 67 RVA: 0x00003514 File Offset: 0x00001714
			internal uint Method2(uint A_1, byte A_2)
			{
				return ((A_1 & this.Field3) << this.Field2) + (uint)(A_2 >> 8 - this.Field2);
			}

			// Token: 0x06000044 RID: 68 RVA: 0x00003544 File Offset: 0x00001744
			internal byte Method3(Class0.Class1 A_1, uint A_2, byte A_3)
			{
				return this.Field0[(int)((UIntPtr)this.Method2(A_2, A_3))].Method2(A_1);
			}

			// Token: 0x06000045 RID: 69 RVA: 0x0000356C File Offset: 0x0000176C
			internal byte Method4(Class0.Class1 A_1, uint A_2, byte A_3, byte A_4)
			{
				return this.Field0[(int)((UIntPtr)this.Method2(A_2, A_3))].Method3(A_1, A_4);
			}

			// Token: 0x06000046 RID: 70 RVA: 0x00002BFC File Offset: 0x00000DFC
			internal Class4()
			{
			}

			// Token: 0x04000020 RID: 32
			internal Class0.Class2.Class4.Struct2[] Field0;

			// Token: 0x04000021 RID: 33
			internal int Field1;

			// Token: 0x04000022 RID: 34
			internal int Field2;

			// Token: 0x04000023 RID: 35
			internal uint Field3;

			// Token: 0x02000008 RID: 8
			internal struct Struct2
			{
				// Token: 0x06000047 RID: 71 RVA: 0x00003598 File Offset: 0x00001798
				internal void Method0()
				{
					this.Field0 = new Class0.Struct0[768];
				}

				// Token: 0x06000048 RID: 72 RVA: 0x000035B8 File Offset: 0x000017B8
				internal void Method1()
				{
					for (int i = 0; i < 768; i++)
					{
						this.Field0[i].Method0();
					}
				}

				// Token: 0x06000049 RID: 73 RVA: 0x000035E8 File Offset: 0x000017E8
				internal byte Method2(Class0.Class1 A_1)
				{
					uint num = 1U;
					do
					{
						num = (num << 1 | this.Field0[(int)((UIntPtr)num)].Method1(A_1));
					}
					while (num < 256U);
					return (byte)num;
				}

				// Token: 0x0600004A RID: 74 RVA: 0x0000361C File Offset: 0x0000181C
				internal byte Method3(Class0.Class1 A_1, byte A_2)
				{
					uint num = 1U;
					for (;;)
					{
						uint num2 = (uint)(A_2 >> 7 & 1);
						A_2 = (byte)(A_2 << 1);
						uint num3 = this.Field0[(int)((UIntPtr)((1U + num2 << 8) + num))].Method1(A_1);
						num = (num << 1 | num3);
						if (num2 != num3)
						{
							break;
						}
						if (num >= 256U)
						{
							goto IL_5E;
						}
					}
					while (num < 256U)
					{
						num = (num << 1 | this.Field0[(int)((UIntPtr)num)].Method1(A_1));
					}
					IL_5E:
					return (byte)num;
				}

				// Token: 0x04000024 RID: 36
				internal Class0.Struct0[] Field0;
			}
		}
	}

	// Token: 0x02000009 RID: 9
	internal class Class5
	{
		// Token: 0x0600004B RID: 75 RVA: 0x0000368C File Offset: 0x0000188C
		internal void Method0(uint A_1)
		{
			if (this.Field4 != A_1)
			{
				this.Field0 = new byte[A_1];
			}
			this.Field4 = A_1;
			this.Field1 = 0U;
			this.Field3 = 0U;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x000036C4 File Offset: 0x000018C4
		internal void Method1(Stream A_1, bool A_2)
		{
			this.Method2();
			this.Field2 = A_1;
			if (!A_2)
			{
				this.Field3 = 0U;
				this.Field1 = 0U;
			}
		}

		// Token: 0x0600004D RID: 77 RVA: 0x000036F0 File Offset: 0x000018F0
		internal void Method2()
		{
			this.Method3();
			this.Field2 = null;
			Buffer.BlockCopy(new byte[this.Field0.Length], 0, this.Field0, 0, this.Field0.Length);
		}

		// Token: 0x0600004E RID: 78 RVA: 0x0000372C File Offset: 0x0000192C
		internal void Method3()
		{
			uint num = this.Field1 - this.Field3;
			if (num == 0U)
			{
				return;
			}
			this.Field2.Write(this.Field0, (int)this.Field3, (int)num);
			if (this.Field1 >= this.Field4)
			{
				this.Field1 = 0U;
			}
			this.Field3 = this.Field1;
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00003784 File Offset: 0x00001984
		internal void Method4(uint A_1, uint A_2)
		{
			uint num = this.Field1 - A_1 - 1U;
			if (num >= this.Field4)
			{
				num += this.Field4;
			}
			while (A_2 > 0U)
			{
				if (num >= this.Field4)
				{
					num = 0U;
				}
				this.Field0[(int)((UIntPtr)(this.Field1++))] = this.Field0[(int)((UIntPtr)(num++))];
				if (this.Field1 >= this.Field4)
				{
					this.Method3();
				}
				A_2 -= 1U;
			}
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00003800 File Offset: 0x00001A00
		internal void Method5(byte A_1)
		{
			this.Field0[(int)((UIntPtr)(this.Field1++))] = A_1;
			if (this.Field1 >= this.Field4)
			{
				this.Method3();
			}
		}

		// Token: 0x06000051 RID: 81 RVA: 0x0000383C File Offset: 0x00001A3C
		internal byte Method6(uint A_1)
		{
			uint num = this.Field1 - A_1 - 1U;
			if (num >= this.Field4)
			{
				num += this.Field4;
			}
			return this.Field0[(int)((UIntPtr)num)];
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00002BFC File Offset: 0x00000DFC
		internal Class5()
		{
		}

		// Token: 0x04000025 RID: 37
		internal byte[] Field0;

		// Token: 0x04000026 RID: 38
		internal uint Field1;

		// Token: 0x04000027 RID: 39
		internal Stream Field2;

		// Token: 0x04000028 RID: 40
		internal uint Field3;

		// Token: 0x04000029 RID: 41
		internal uint Field4;
	}

	// Token: 0x0200000A RID: 10
	internal struct Struct3
	{
		// Token: 0x06000053 RID: 83 RVA: 0x00003870 File Offset: 0x00001A70
		internal void Method0()
		{
			this.Field0 = 0U;
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00003884 File Offset: 0x00001A84
		internal void Method1()
		{
			if (this.Field0 < 4U)
			{
				this.Field0 = 0U;
				return;
			}
			if (this.Field0 >= 10U)
			{
				this.Field0 -= 6U;
				return;
			}
			this.Field0 -= 3U;
		}

		// Token: 0x06000055 RID: 85 RVA: 0x000038CC File Offset: 0x00001ACC
		internal void Method2()
		{
			this.Field0 = ((this.Field0 < 7U) ? 7U : 10U);
		}

		// Token: 0x06000056 RID: 86 RVA: 0x000038F0 File Offset: 0x00001AF0
		internal void Method3()
		{
			this.Field0 = ((this.Field0 < 7U) ? 8U : 11U);
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00003914 File Offset: 0x00001B14
		internal void Method4()
		{
			this.Field0 = ((this.Field0 < 7U) ? 9U : 11U);
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00003938 File Offset: 0x00001B38
		internal bool Method5()
		{
			return this.Field0 < 7U;
		}

		// Token: 0x0400002A RID: 42
		internal uint Field0;
	}

	// Token: 0x0200000B RID: 11
	[StructLayout(LayoutKind.Explicit, Size = 384)]
	internal struct Struct4
	{
	}

	// Token: 0x0200000C RID: 12
	[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 576)]
	internal struct Struct5
	{
	}
}
