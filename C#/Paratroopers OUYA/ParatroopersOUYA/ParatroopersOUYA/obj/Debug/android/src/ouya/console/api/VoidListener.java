package ouya.console.api;


public class VoidListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		tv.ouya.console.api.OuyaResponseListener
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCancel:()V:GetOnCancelHandler:Ouya.Console.Api.IOuyaResponseListenerInvoker, Ouya.Console.Api\n" +
			"n_onFailure:(ILjava/lang/String;Landroid/os/Bundle;)V:GetOnFailure_ILjava_lang_String_Landroid_os_Bundle_Handler:Ouya.Console.Api.IOuyaResponseListenerInvoker, Ouya.Console.Api\n" +
			"n_onSuccess:(Ljava/lang/Object;)V:GetOnSuccess_Ljava_lang_Object_Handler:Ouya.Console.Api.IOuyaResponseListenerInvoker, Ouya.Console.Api\n" +
			"";
		mono.android.Runtime.register ("Ouya.Console.Api.VoidListener, Ouya.Console.Api, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null", VoidListener.class, __md_methods);
	}


	public VoidListener ()
	{
		super ();
		if (getClass () == VoidListener.class)
			mono.android.TypeManager.Activate ("Ouya.Console.Api.VoidListener, Ouya.Console.Api, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCancel ()
	{
		n_onCancel ();
	}

	private native void n_onCancel ();


	public void onFailure (int p0, java.lang.String p1, android.os.Bundle p2)
	{
		n_onFailure (p0, p1, p2);
	}

	private native void n_onFailure (int p0, java.lang.String p1, android.os.Bundle p2);


	public void onSuccess (java.lang.Object p0)
	{
		n_onSuccess (p0);
	}

	private native void n_onSuccess (java.lang.Object p0);

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
