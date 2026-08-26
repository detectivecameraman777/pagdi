using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

// Token: 0x0200002D RID: 45
public partial class Class35 : Form
{
	// Token: 0x06000148 RID: 328 RVA: 0x00008AC4 File Offset: 0x00006CC4
	public Class35()
	{
		this.Method1();
	}

	// Token: 0x06000149 RID: 329 RVA: 0x00008AE0 File Offset: 0x00006CE0
	protected virtual void Method0(bool A_1)
	{
		if (A_1 && this.Field0 != null)
		{
			Class35.StaticMethod0(this.Field0);
		}
		base.Dispose(A_1);
	}

	// Token: 0x0600014A RID: 330 RVA: 0x00008B0C File Offset: 0x00006D0C
	private void Method1()
	{
		this.Field0 = Class35.StaticMethod1();
		Class35.StaticMethod2(this, AutoScaleMode.Font);
		base.ClientSize = new Size(800, 450);
		this.Text = "Form1";
	}

	// Token: 0x0600014B RID: 331 RVA: 0x00005BCC File Offset: 0x00003DCC
	static void StaticMethod0(IDisposable A_0)
	{
		A_0.Dispose();
	}

	// Token: 0x0600014C RID: 332 RVA: 0x00008B4C File Offset: 0x00006D4C
	static Container StaticMethod1()
	{
		return new Container();
	}

	// Token: 0x0600014D RID: 333 RVA: 0x00008B60 File Offset: 0x00006D60
	static void StaticMethod2(ContainerControl A_0, AutoScaleMode A_1)
	{
		A_0.AutoScaleMode = A_1;
	}

	// Token: 0x0400006A RID: 106
	private IContainer Field0;
}
