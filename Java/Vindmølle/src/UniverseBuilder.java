import java.awt.*;
import java.awt.event.*;

import javax.media.j3d.*;
import javax.vecmath.*;

public class UniverseBuilder extends Object {
	
    // User-specified canvas
    Canvas3D canvas;

    // Scene graph elements to which the user may want access
    VirtualUniverse             universe;
    Locale                      locale;
    TransformGroup              vpTrans;
    View                        view;
    KeyEvent					argument;

    @SuppressWarnings("restriction")
	public UniverseBuilder(Canvas3D c) {
        this.canvas = c;
        KeyPressed kp= new KeyPressed();
        c.addKeyListener(kp);
        // Establish a virtual universe that has a single
        // hi-res Locale
        universe = new VirtualUniverse();
        locale = new Locale(universe);

        // Create a PhysicalBody and PhysicalEnvironment object
        PhysicalBody body = new PhysicalBody();
        PhysicalEnvironment environment = new PhysicalEnvironment();

        // Create a View and attach the Canvas3D and the physical
        // body and environment to the view.
        view = new View();
        view.addCanvas3D(c);
        view.setPhysicalBody(body);
        view.setPhysicalEnvironment(environment);
        view.setBackClipDistance(2000);

        // Create a BranchGroup node for the view platform
        BranchGroup vpRoot = new BranchGroup();
        
        
        TransformGroup objTrans = new TransformGroup();
        
        objTrans.setCapability(
                            TransformGroup.ALLOW_TRANSFORM_WRITE);
        vpRoot.addChild(objTrans);
        // Create a ViewPlatform object, and its associated
        // TransformGroup object, and attach it to the root of the
        // subgraph. Attach the view to the view platform.
        Transform3D Xaxis = new Transform3D();
        
        Transform3D Spinmeroundbaby = new Transform3D();
        
        
        Spinmeroundbaby.rotX(-Math.PI/2);
        Alpha rotationAlpha = new Alpha(
                -1, Alpha.INCREASING_ENABLE,
                0, 0,            4000, 0, 0,                        0, 0, 0);
        
        RotationInterpolator rotator = new RotationInterpolator(
                rotationAlpha, objTrans, Spinmeroundbaby,
                0.0f, (float) Math.PI*2.0f);
        
        BoundingSphere bounds =
            new BoundingSphere(new Point3d(0.0,0.0,0.0), 100.0);
        rotator.setSchedulingBounds(bounds);
        
        Xaxis.set(new Vector3f(0.0f, -10.0f, 140.0f)); //X Y Z
        ViewPlatform vp = new ViewPlatform();
        
        vpTrans = new TransformGroup(Xaxis);

        
//        objTrans.addChild(rotator);
        objTrans.addChild(vpTrans);
        vpTrans.addChild(vp);

        view.attachViewPlatform(vp);

        // Attach the branch graph to the universe, via the
        // Locale. The scene graph is now live!
        locale.addBranchGraph(vpRoot);
    }

    public void addBranchGraph(BranchGroup bg) {
        locale.addBranchGraph(bg);
    }
}