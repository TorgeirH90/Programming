import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;


public class KeyPressed implements KeyListener {
char plus= '+';
int FanSpeed=4000;
char Minos='-';
HelloUniverse 	hu;
	@SuppressWarnings("restriction")
	@Override
	public void keyPressed(KeyEvent argument) {
		char c=argument.getKeyChar();
		if (c==plus){
			hu.rotationAlphaBlad1.setIncreasingAlphaDuration(500);
		}
		if (c==Minos){
			FanSpeed=FanSpeed-1000;
		}
		System.out.println(FanSpeed);
	}

	public int getFanSpeed() {
		return FanSpeed;
	}

	public void setFanSpeed(int fanSpeed) {
		FanSpeed = fanSpeed;
	}

	@Override
	public void keyReleased(KeyEvent arg0) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void keyTyped(KeyEvent arg0) {
		// TODO Auto-generated method stub
		
	}

}