using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;

// Token: 0x0200002E RID: 46
[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
[CompilerGenerated]
[DebuggerNonUserCode]
internal class Class36
{
	// Token: 0x0600014E RID: 334 RVA: 0x00002BFC File Offset: 0x00000DFC
	internal Class36()
	{
	}

	// Token: 0x17000001 RID: 1
	// (get) Token: 0x0600014F RID: 335 RVA: 0x00008B74 File Offset: 0x00006D74
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static ResourceManager Prop0
	{
		get
		{
			if (Class36.Field0 == null)
			{
				Class36.Field0 = Class36.StaticMethod5("^#CvDM_Tbx9Kl\\\\B#`ax _|aA\\&", Class36.StaticMethod4(Class36.StaticMethod3(typeof(Class36).TypeHandle)));
			}
			return Class36.Field0;
		}
	}

	// Token: 0x17000002 RID: 2
	// (get) Token: 0x06000150 RID: 336 RVA: 0x00008BAC File Offset: 0x00006DAC
	// (set) Token: 0x06000151 RID: 337 RVA: 0x00008BC0 File Offset: 0x00006DC0
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static CultureInfo Prop1
	{
		get
		{
			return Class36.Field1;
		}
		set
		{
			Class36.Field1 = value;
		}
	}

	// Token: 0x06000152 RID: 338 RVA: 0x00002370 File Offset: 0x00000570
	static Type StaticMethod3(RuntimeTypeHandle A_0)
	{
		return Type.GetTypeFromHandle(A_0);
	}

	// Token: 0x06000153 RID: 339 RVA: 0x00008BD4 File Offset: 0x00006DD4
	static Assembly StaticMethod4(Type A_0)
	{
		return A_0.Assembly;
	}

	// Token: 0x06000154 RID: 340 RVA: 0x00008BE8 File Offset: 0x00006DE8
	static ResourceManager StaticMethod5(string A_0, Assembly A_1)
	{
		return new ResourceManager(A_0, A_1);
	}

	// Token: 0x0400006B RID: 107
	private static ResourceManager Field0;

	// Token: 0x0400006C RID: 108
	private static CultureInfo Field1;
}
