import netP5.*;
import oscP5.*;
import controlP5.*;
import processing.video.*;

Capture video;

color trackColor;
color trackColorR;
color trackColorG;
color trackColorB;
color trackColorY;

float threshold = 25;

ColorTracker[] colorTrackers = new ColorTracker[4];

OscP5 oscP5;
NetAddress myRemoteLocation;

void setup() 
{
  size(320, 240);
  //String[] cameras = Capture.list();
  //printArray(cameras);
  video = new Capture(this, 320, 240, 30);
  video.start();
  trackColor = color(254, 77, 61); //track a red image on a screen
  trackColorR = color(255.0, 67.0, 59.0); //track a red image on a screen
  trackColorG = color(149.0, 196.0, 48.0); //track a green image on a screen
  trackColorB = color(147.0, 253.0, 255.0); //track a blue image on a screen
  trackColorY = color(253.0, 252.0, 143.0); //track a yellow image on a screen

  oscP5 = new OscP5(this,11000);//listening port, just in case
  myRemoteLocation = new NetAddress("127.0.0.1",1234);//sending port
  
  colorTrackers[0] = new ColorTracker(trackColorR);
  colorTrackers[1] = new ColorTracker(trackColorG);
  colorTrackers[2] = new ColorTracker(trackColorB);
  colorTrackers[3] = new ColorTracker(trackColorY);
}

void captureEvent(Capture video) 
{
  video.read();
}

void draw() 
{
  background(0);
  video.loadPixels();
  image(video, 0, 0);
  noFill();
  stroke(0);
  rect(0,0,320,240);
  
  //update trackers
  //colorTrackers[0].setValue(tracker1R,tracker1G,tracker1B);
  colorTrackers[0].setPosition(video);
  colorTrackers[0].display();
  
  colorTrackers[1].setPosition(video);
  colorTrackers[1].display();
  
  colorTrackers[2].setPosition(video);
  colorTrackers[2].display();
  
  colorTrackers[3].setPosition(video);
  colorTrackers[3].display();
  
  sendPositionsOSC();
}

float distSq(float x1, float y1, float z1, float x2, float y2, float z2) 
{
  float d = (x2-x1)*(x2-x1) + (y2-y1)*(y2-y1) +(z2-z1)*(z2-z1);
  return d;
}

void mousePressed() 
{
  // Save color where the mouse is clicked in trackColor variable
  int loc = mouseX + mouseY*video.width;
  trackColor = video.pixels[loc];
  println( "Clicked Color:: " + 
            red(trackColor) + ", " +
            green(trackColor) + ", " +
            blue(trackColor));
}

void keyPressed()
{
  switch(key)
  {
    //set a colorTracker's value to the current trackColor value
    //i.e. pressing 'r', 'g', 'b', 'y'
    //changes the red, green, blue, and yellow trackers
    case 'r':
      colorTrackers[0].setValue(trackColor);
      break;
    case 'g':
      colorTrackers[1].setValue(trackColor);
      break;
    case 'b':
      colorTrackers[2].setValue(trackColor);
      break;
    case 'y':
      colorTrackers[3].setValue(trackColor);
      break;
  }
}

void sendPositionsOSC()
{
  for( int i = 0; i < colorTrackers.length; i++ )
  {
    String colorName = "";
    switch( i )
    {
      case 0:
        colorName = "red";
        break;
      case 1:
        colorName = "green";
        break;
      case 2:
        colorName = "blue";
        break;
      case 3:
        colorName = "yellow";
        break;
    }
    //normalize the postion of the tracker in relation
    //to the center of the screen
    PVector temp = colorTrackers[i].getPosition();
    temp.sub( new PVector( (float)width/2, (float)height/2 ) );
    temp.normalize();
    
    sendColorOSC(colorName+"X", temp.x );
    sendColorOSC(colorName+"Y", temp.y );
  }
}

void sendColorOSC(String colorAndXorY, float posFloat)
{
  //add the color you are sending, plus the x or y value
  //of the position that you are updating (e.g. "redX")
  OscMessage myMessage = new OscMessage("/"+colorAndXorY);
  
  //add one of the postion values for that color (e.g. colorTrackers[0].getPosition().x )
  myMessage.add(posFloat); /* add a float to the osc message */

  /* send the message */
  oscP5.send(myMessage, myRemoteLocation); 
}