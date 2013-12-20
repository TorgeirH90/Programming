import java.applet.Applet;
import java.awt.*;
import java.awt.event.*;

import javax.media.j3d.*;
import javax.vecmath.*;

import com.mnstarfire.loaders3d.Inspector3DS;

@SuppressWarnings("serial")
public class HelloUniverse extends Applet implements KeyListener {
	char plus= '+';
	int FanSpeed=4000;
	char Minos='-';
	Alpha rotationAlphaBlad1;
    
	@SuppressWarnings("restriction")
	public BranchGroup createSceneGraph() {
        // Create the root of the branch graph
        BranchGroup objRoot = new BranchGroup();
        // Create the TransformGroup node and initialize it to the
        // identity. Enable the TRANSFORM_WRITE capability so that
        // our behavior code can modify it at run time. Add it to
        // the root of the subgraph.
        TransformGroup objTrans = new TransformGroup();
        objTrans.setCapability(TransformGroup.ALLOW_TRANSFORM_WRITE);
        objRoot.addChild(objTrans);
        
     // Setter på lys slik at modellen blir synlig

        BoundingSphere boundsb = new BoundingSphere(new Point3d(0.0,0.0,0.0), 500.0);


        AmbientLight al = new AmbientLight(true,new Color3f(1,1,1));
        al.setInfluencingBounds(boundsb);

        Point3f point = new Point3f(60,0,120);
        PointLight lgt1 = new PointLight();
        SpotLight lgt2 = new SpotLight();
        Color3f lColor1 = new Color3f(0.5f,0.5f,0.5f);
        lgt1.setPosition(point);
        lgt1.setColor(lColor1);
        lgt1.setInfluencingBounds(boundsb);
        
        lgt2.setDirection(-100.0f, 0.0f, -100.0f);
        lgt2.setPosition(100.0f, 0.0f, 100.0f);
        lgt2.setSpreadAngle((float)Math.PI/64);
        lgt2.setInfluencingBounds(boundsb);

        objRoot.addChild(lgt1);
//        objRoot.addChild(lgt2);
        objRoot.addChild(al);
        
//        hvit bakgrunn 
        Background b=new Background(1,1,1);
        BoundingSphere boundsc = new BoundingSphere(new Point3d(0.0,0.0,0.0), 500.0);
        b.setApplicationBounds(boundsc);
//        objRoot.addChild(b);
        
        
        // Create a simple Shape3D node; add it to the scene graph.
        
//        create søyle
        Inspector3DS loader = new Inspector3DS("C:/threeD/1Model.3DS");
		loader.parseIt();
		TransformGroup theModel = loader.getModel();
		objTrans.addChild(theModel);

		
	// create BLAD1
		 Inspector3DS loaderblad1 = new Inspector3DS("C:/threeD/blad.3DS");
			loaderblad1.parseIt();
			TransformGroup theModelblad1 = loaderblad1.getModel();
			// create BLAD2
		 Inspector3DS loaderblad2 = new Inspector3DS("C:/threeD/blad.3DS");
			loaderblad2.parseIt();
			TransformGroup theModelblad2 = loaderblad2.getModel();
			// create BLAD2
		 Inspector3DS loaderblad3 = new Inspector3DS("C:/threeD/blad.3DS");
			loaderblad3.parseIt();
			TransformGroup theModelblad3 = loaderblad3.getModel();
				
		//Transformgroups
			//Blad1
			TransformGroup blad1rot = new TransformGroup();
			
			
			blad1rot.setCapability(TransformGroup.ALLOW_TRANSFORM_WRITE);
			Transform3D Blad1Xaxis = new Transform3D();
			Blad1Xaxis.rotX(Math.PI/2);										    // tid
			rotationAlphaBlad1 = new Alpha(-1, Alpha.INCREASING_ENABLE, 0, 0,4000, 0, 0,                        0, 0, 0);
			RotationInterpolator rotatorBlad1 = new RotationInterpolator(rotationAlphaBlad1, blad1rot, Blad1Xaxis,
		0.0f, (float) Math.PI*2.0f);
	        BoundingSphere boundsBlad1 = new BoundingSphere(new Point3d(0.0,0.0,0.0), 100.0);
	        rotatorBlad1.setSchedulingBounds(boundsBlad1);
	        
	        
	        //Blad1
	        theModel.addChild(blad1rot);
	        
	        blad1rot.addChild(theModelblad1);
	        
	        blad1rot.addChild(rotatorBlad1);
		
	        //Blad2
	        Transform3D Blad2Xaxis = new Transform3D();
			Blad2Xaxis.rotZ(2*Math.PI/3);	
			TransformGroup blad2rot = new TransformGroup(Blad2Xaxis);
			theModelblad1.addChild(blad2rot);
			
			blad2rot.setCapability(TransformGroup.ALLOW_TRANSFORM_WRITE);
												    
			
	        
	        blad2rot.addChild(theModelblad2);
	        //Blad 3
	        
	        Transform3D Blad3Xaxis = new Transform3D();
			Blad3Xaxis.rotZ(2*Math.PI/3);
			Blad3Xaxis.rotZ(2*Math.PI/3);
	        
	        TransformGroup blad3rot = new TransformGroup(Blad3Xaxis);
	        theModelblad2.addChild(blad3rot);
	        blad3rot.addChild(theModelblad3);
        // Create a new Behavior object that will perform the
        // desired operation on the specified transform and add
        // it into the scene graph.
        BoundingSphere bounds = new BoundingSphere(new Point3d(0.0,0.0,0.0), 100.0);

        return objRoot;
    }
	
	
	@SuppressWarnings("restriction")
	public void keyPressed(KeyEvent argument) {
		long oldvalue= rotationAlphaBlad1.getIncreasingAlphaDuration();
		char c=argument.getKeyChar();
		if (c==plus){
			rotationAlphaBlad1.setIncreasingAlphaDuration(oldvalue*2);
		}
		if (c==Minos){
			FanSpeed=FanSpeed-1000;
		}
		System.out.println(FanSpeed);
	}

    @SuppressWarnings("restriction")
	public HelloUniverse() {
        setLayout(new BorderLayout());
        GraphicsConfigTemplate template = new GraphicsConfigTemplate3D();
        GraphicsConfiguration gcfg =GraphicsEnvironment.getLocalGraphicsEnvironment().
            getDefaultScreenDevice().getBestConfiguration(template);
        Canvas3D c = new Canvas3D(gcfg);
        add("Center", c);
        // Create a simple scene and attach it to the virtual
        // universe
        BranchGroup scene = createSceneGraph();
        UniverseBuilder u = new UniverseBuilder(c);
        u.addBranchGraph(scene);
    }


	@Override
	public void keyReleased(KeyEvent e) {
		// TODO Auto-generated method stub
		
	}


	@Override
	public void keyTyped(KeyEvent e) {
		// TODO Auto-generated method stub
		
	}
}