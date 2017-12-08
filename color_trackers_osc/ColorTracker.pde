class ColorTracker
{
  color value;
  PVector position;
  
  ColorTracker()
  {
    value = color(0);
    position = new PVector(0,0);
  }
  
  ColorTracker(color c)
  {
    value = color(c);
    position = new PVector(0,0);
  }
  
  void setValue(int r, int g, int b)
  {
    this.value = color(r,g,b);
  }
  
  void setValue(color c)
  {
    this.value = c;
  }
  
  color getValue()
  {
    return this.value;
  }
  
  void setPosition(Capture video)
  {
    float avgX = 0;
    float avgY = 0;
  
    int count = 0;
    
    for (int x = 0; x < video.width; x++ ) {
      for (int y = 0; y < video.height; y++ ) {
        int loc = x + y * video.width;
        // What is current color
        color currentColor = video.pixels[loc];
        float r1 = red(currentColor);
        float g1 = green(currentColor);
        float b1 = blue(currentColor);
        float r2 = red(this.value);
        float g2 = green(this.value);
        float b2 = blue(this.value);
  
        float d = distSq(r1, g1, b1, r2, g2, b2); 
  
        if (d < threshold*threshold) {
          stroke(255);
          strokeWeight(1);
          point(x, y);
          avgX += x;
          avgY += y;
          count++;
        }
      }
    }
    
    if (count > 0) 
    { 
      this.position.set( avgX / count, avgY / count );
    }
    
    
  }
  
  PVector getPosition()
  {
    return this.position;
  }
  
  void display()
  {
    fill(this.value);
    strokeWeight(4.0);
    stroke(0);
    ellipse(this.position.x, this.position.y, 24, 24);
  }
}