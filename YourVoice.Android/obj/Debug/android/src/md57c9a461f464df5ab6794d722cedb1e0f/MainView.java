package md57c9a461f464df5ab6794d722cedb1e0f;


public class MainView
	extends md5716162e2cd7f7ce01364d7c5d961f40b.MvxAppCompatActivity_1
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("YourVoice.Android.Views.MainView, YourVoice.Android", MainView.class, __md_methods);
	}


	public MainView ()
	{
		super ();
		if (getClass () == MainView.class)
			mono.android.TypeManager.Activate ("YourVoice.Android.Views.MainView, YourVoice.Android", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
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
