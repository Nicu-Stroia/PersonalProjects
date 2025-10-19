#include "glos.h"

#include <GL/gl.h>
#include <GL/glu.h>
#include "glaux.h"

#include <stdio.h>
#include <math.h>
#include <string.h>

static float transX = 0.0f;
static float transY = 0.0f;
static float rotAng = 0.0f;
static float rotAngX = 0.0f;
static float rotAngY = 0.0f;

static float flowerTransX = 0.0f;  
static float flowerTransY = 0.0f;  
static float flowerTransZ = 0.0f;  
static float flowerRotY = 0.0f;

static float flowerOrbitAngle = 0.0f;

float eyeX = 0.0f, eyeY = 0.0f, eyeZ = 8.0f;      
float centerX = 0.0f, centerY = 0.0f, centerZ = 0.0f; 

#define stripeImageWidth 64
#define stripeImageHeight 64
GLubyte stripeImage[stripeImageHeight][stripeImageWidth][3];

GLfloat petal[4][3] = {
	{0.0f, 0.0f, 0.0f},     
	{0.3f, 0.2f, 0.0f},     
	{0.6f, 0.4f, 0.0f},     
	{0.8f, 0.0f, 0.0f}      
};

GLuint textureID;


GLubyte myNameRasters[13][13] = {
	{0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00},
	{0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xff, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00},
	{0x00, 0x00, 0xc3, 0xc3, 0xc3, 0xc3, 0xff, 0xc3, 0xc3, 0xc3, 0x66, 0x3c, 0x18},
	{0x00, 0x00, 0x7c, 0xc6, 0xc0, 0xc0, 0xc0, 0xc0, 0xc0, 0xc0, 0xc6, 0x7c, 0x00},
	{0x00, 0x00, 0xff, 0xc0, 0xc0, 0xc0, 0xc0, 0xfc, 0xc0, 0xc0, 0xc0, 0xc0, 0xff},
	{0x00, 0x00, 0x7e, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0x7e, 0x00},
	{0x00, 0x00, 0xff, 0xc0, 0xc0, 0xc0, 0xc0, 0xc0, 0xc0, 0xc0, 0xc0, 0xc0, 0x00},
	{0x00, 0x00, 0xc3, 0xc7, 0xcf, 0xdf, 0xdb, 0xfb, 0xf3, 0xe3, 0xc3, 0xc3, 0x00},
	{0x00, 0x00, 0x7c, 0xc6, 0xc6, 0xc6, 0xc6, 0xc6, 0xc6, 0xc6, 0xc6, 0x7c, 0x00},
	{0x00, 0x00, 0xc3, 0xc6, 0xcc, 0xd8, 0xf0, 0xfe, 0xc6, 0xc6, 0xc6, 0xfc, 0x00},
	{0x00, 0x00, 0x7c, 0xc6, 0x06, 0x06, 0x3c, 0x60, 0xc0, 0xc0, 0xc6, 0x7c, 0x00},
	{0x00, 0x00, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0xff, 0xff, 0x00},
	{0x00, 0x00, 0x7c, 0xc6, 0xc6, 0xc6, 0xc6, 0xc6, 0xc6, 0xc6, 0xc6, 0xc6, 0x00}
};

GLuint fontOffset;

GLfloat vaseMaterial[4] = { 0.8, 0.7, 0.5, 1.0 };  
GLfloat flowerMaterial[4] = { 1.0, 0.4, 0.6, 1.0 }; 
GLfloat stemMaterial[4] = { 0.2, 0.7, 0.2, 1.0 };   

void makeMyNameFont()
{
	fontOffset = glGenLists(128);

	int charMap[128];
	for (int i = 0; i < 128; i++) {
		charMap[i] = 0;
	}

	charMap[32] = 0;  
	charMap[45] = 1;  
	charMap[65] = 2; 
	charMap[67] = 3;  
	charMap[69] = 4;  
	charMap[73] = 5;  
	charMap[76] = 6;  
	charMap[78] = 7;  
	charMap[79] = 8;  
	charMap[82] = 9; 
	charMap[83] = 10; 
	charMap[84] = 11; 
	charMap[85] = 12; 

	for (int i = 0; i < 128; i++) {
		glNewList(i + fontOffset, GL_COMPILE);
		glBitmap(8, 13, 0.0, 0.0, 10.0, 0.0, myNameRasters[charMap[i]]);
		glEndList();
	}
}

void printString(const char* s)
{
	glPushAttrib(GL_LIST_BIT);
	glListBase(fontOffset);
	glCallLists(strlen(s), GL_UNSIGNED_BYTE, (GLubyte*)s);
	glPopAttrib();
}

void makeStripeImage()
{
	for (int i = 0; i < stripeImageHeight; i++) {
		for (int j = 0; j < stripeImageWidth; j++) {
			if ((j / 8) % 2 == 0) {
				stripeImage[i][j][0] = 240; 
				stripeImage[i][j][1] = 220;  
				stripeImage[i][j][2] = 180;
			}
			else {
				stripeImage[i][j][0] = 120; 
				stripeImage[i][j][1] = 80;  
				stripeImage[i][j][2] = 40;  
			}
		}
	}
}

void loadTexture() {
	makeStripeImage();
	glPixelStorei(GL_UNPACK_ALIGNMENT, 1);
	glTexImage2D(GL_TEXTURE_2D, 0, 3, stripeImageWidth, stripeImageHeight, 0, GL_RGB, GL_UNSIGNED_BYTE, &stripeImage[0][0][0]);
	glTexParameterf(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
	glTexParameterf(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);
	glTexParameterf(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_REPEAT);
	glTexParameterf(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_REPEAT);
	glTexEnvf(GL_TEXTURE_ENV, GL_TEXTURE_ENV_MODE, GL_MODULATE);
}

void myInit(void) {
	glClearColor(1.0f, 1.0f, 1.0f, 1.0f);
	glEnable(GL_DEPTH_TEST);
	loadTexture();
	makeMyNameFont();

	GLfloat mat_ambient[] = { 0.3, 0.3, 0.3, 1.0 };
	GLfloat mat_specular[] = { 0.8, 0.8, 0.8, 1.0 };
	GLfloat mat_shininess[] = { 30.0 };

	glMaterialfv(GL_FRONT_AND_BACK, GL_AMBIENT, mat_ambient);
	glMaterialfv(GL_FRONT_AND_BACK, GL_SPECULAR, mat_specular);
	glMaterialfv(GL_FRONT_AND_BACK, GL_SHININESS, mat_shininess);

	GLfloat light_ambient[] = { 0.4, 0.4, 0.4, 1.0 };
	GLfloat light_diffuse[] = { 0.8, 0.8, 0.8, 1.0 };
	GLfloat light_specular[] = { 1.0, 1.0, 1.0, 1.0 };
	GLfloat light_position[] = { 0.0, 200.0, 200.0, 1.0 }; 

	glLightfv(GL_LIGHT0, GL_AMBIENT, light_ambient);
	glLightfv(GL_LIGHT0, GL_DIFFUSE, light_diffuse);
	glLightfv(GL_LIGHT0, GL_SPECULAR, light_specular);
	glLightfv(GL_LIGHT0, GL_POSITION, light_position);

	glEnable(GL_LIGHTING);
	glEnable(GL_LIGHT0);
	glEnable(GL_NORMALIZE);
	glEnable(GL_AUTO_NORMAL); 
}

void drawVase() {
	GLUquadricObj* q = gluNewQuadric();
	gluQuadricNormals(q, GLU_SMOOTH); 

	glPushMatrix();
	glRotatef(-90.0f, 1, 0, 0);

	glMaterialfv(GL_FRONT_AND_BACK, GL_DIFFUSE, vaseMaterial);
	gluDisk(q, 0.0, 15, 40, 1);
	glTranslatef(0.0f, 0.0f, -18.0f);

	glEnable(GL_TEXTURE_2D);
	glBindTexture(GL_TEXTURE_2D, textureID);
	gluQuadricTexture(q, GL_TRUE);

	glTranslatef(0.0f, 0.0f, 0.0f);
	gluCylinder(q, 35.0, 15.0, 18.0, 30, 8);
	glTranslatef(0.0f, 0.0f, 15.0f);

	gluCylinder(q, 15.0, 35.0, 27.0, 30, 8);
	glTranslatef(0.0f, 0.0f, 27.0f);

	gluCylinder(q, 35.0, 35.0, 36.0, 30, 8);
	glTranslatef(0.0f, 0.0f, 36.0f);

	gluCylinder(q, 35.0, 40.0, 9.0, 30, 8);

	glDisable(GL_TEXTURE_2D);

	GLfloat waterMaterial[4] = { 0.0, 0.749, 1.0, 1.0 };
	glMaterialfv(GL_FRONT_AND_BACK, GL_DIFFUSE, waterMaterial);
	gluDisk(q, 0.0, 35.0, 30, 1);

	glTranslatef(0.0f, 0.0f, -90.0f);
	glPopMatrix();

	gluDeleteQuadric(q);
}

void drawFlower()
{
	const float scale = 36.0f;
	const float bulbRadius = 0.4f;
	const float stemHeight = 60.0f;

	glPushMatrix();
	glRotatef(-90.0f, 1, 0, 0);
	glMaterialfv(GL_FRONT_AND_BACK, GL_DIFFUSE, stemMaterial);
	GLUquadricObj* stem = gluNewQuadric();
	gluQuadricNormals(stem, GLU_SMOOTH); 
	gluCylinder(stem, 2.5f, 1.8f, stemHeight, 16, 4);
	gluDeleteQuadric(stem);
	glPopMatrix();

	glPushMatrix();
	glTranslatef(0.0f, stemHeight, 0.0f);
	glScalef(scale, scale, scale);

	glMap1f(GL_MAP1_VERTEX_3, 0.0f, 1.0f, 3, 4, &petal[0][0]);
	glEnable(GL_MAP1_VERTEX_3);

	for (int i = 0; i < 24; ++i) {
		glPushMatrix();
		glRotatef(i * 50.0f, 0.0f, 1.0f, 0.0f);

		GLfloat brightFlowerMaterial[4] = { 1.0, 0.6, 0.8, 1.0 };
		glMaterialfv(GL_FRONT_AND_BACK, GL_DIFFUSE, brightFlowerMaterial);
		GLfloat emission[4] = { 0.2, 0.1, 0.15, 1.0 };
		glMaterialfv(GL_FRONT_AND_BACK, GL_EMISSION, emission);

		glTranslatef(0.0f, 0.2f, 0.0f);

		glLineWidth(7.0f);

		glBegin(GL_LINE_STRIP);
		for (int j = 0; j <= 20; ++j) {
			glPushMatrix();
			glScalef(0.8f, 1.0f, 0.8f);
			glEvalCoord1f((float)j / 20.0f);
			glPopMatrix();
		}
		glEnd();

		glPopMatrix();
	}

	glDisable(GL_MAP1_VERTEX_3);

	GLfloat bulbMaterial[4] = { 1.0, 0.9, 0.2, 1.0 };
	glMaterialfv(GL_FRONT_AND_BACK, GL_DIFFUSE, bulbMaterial);
	GLUquadricObj* q = gluNewQuadric();
	gluQuadricNormals(q, GLU_SMOOTH);
	gluSphere(q, bulbRadius, 16, 16);
	gluDeleteQuadric(q);

	glPopMatrix();
}


void drawThreeFlowers()
{
	const float R = 20.0f;
	const float PI = 3.14159265358979323846f;

	glPushMatrix();

	glTranslatef(flowerTransX, flowerTransY, flowerTransZ);

	glRotatef(flowerOrbitAngle, 0.0f, 1.0f, 1.0f);

	glRotatef(flowerRotY, 0.0f, 1.0f, 0.0f);

	for (int i = 0; i < 3; ++i) {
		float angle = i * 120.0f * (PI / 180.0f);
		float x = R * cosf(angle);
		float z = R * sinf(angle);

		glPushMatrix();
		glTranslatef(x, 60.0f, z);
		glScalef(0.7f, 0.7f, 0.7f);
		drawFlower();
		glPopMatrix();
	}

	glPopMatrix();
}

void drawMyNameOverlay()
{
	glMatrixMode(GL_PROJECTION);
	glPushMatrix();
	glLoadIdentity();
	glOrtho(0.0, 800.0, 0.0, 600.0, -1.0, 1.0);

	glMatrixMode(GL_MODELVIEW);
	glPushMatrix();
	glLoadIdentity();

	glDisable(GL_LIGHTING); 
	glDisable(GL_DEPTH_TEST);
	glColor3f(0.0f, 0.0f, 0.0f);
	glRasterPos2f(280.0f, 50.0f);
	printString("STROIA NICOLAE-AURELIAN");
	glEnable(GL_DEPTH_TEST);
	glEnable(GL_LIGHTING); 

	glPopMatrix();
	glMatrixMode(GL_PROJECTION);
	glPopMatrix();
	glMatrixMode(GL_MODELVIEW);
}

void CALLBACK moveLeft() { rotAng -= 5.0f; }
void CALLBACK moveRight() { rotAng += 5.0f; }
void CALLBACK moveUp() { rotAngX -= 5.0f; }
void CALLBACK moveDown() { rotAngX += 5.0f; }
void CALLBACK moveForward() { eyeZ -= 0.5f; }  
void CALLBACK moveBackward() { eyeZ += 0.5f; } 
void CALLBACK cameraUp() { eyeY += 0.5f; }     
void CALLBACK cameraDown() { eyeY -= 0.5f; }   
void CALLBACK cameraLeft() { eyeX -= 0.5f; }   
void CALLBACK cameraRight() { eyeX += 0.5f; }  
void CALLBACK lookUp() { centerY += 0.5f; }    
void CALLBACK lookDown() { centerY -= 0.5f; }  
void CALLBACK transLeft() {
	if (transX < -360) {
		transX = 0;
	}
	transX -= 5.0f;
}
void CALLBACK transRight() {
	if (transX > 360) {
		transX = 0;
	}
	transX += 5.0f;
}
void CALLBACK transUpward() {
	if (transY > 360) {
		transY = 0;
	}
	transY += 5.0f;
}
void CALLBACK transDownward() {
	if (transY < -360) {
		transY = 0;
	}
	transY -= 5.0f;
}
void CALLBACK resetCamera() {
	eyeX = 0.0f; eyeY = 0.0f; eyeZ = 8.0f;
	centerX = 0.0f; centerY = 0.0f; centerZ = 0.0f;
}
void CALLBACK exitApp() { exit(0); }

void CALLBACK flowerLeft() { flowerTransX -= 2.0f; }
void CALLBACK flowerRight() { flowerTransX += 2.0f; }
void CALLBACK flowerUp() { flowerTransY += 2.0f; }
void CALLBACK flowerDown() { flowerTransY -= 2.0f; }
void CALLBACK flowerForward() { flowerTransZ -= 2.0f; }
void CALLBACK flowerBackward() { flowerTransZ += 2.0f; }
void CALLBACK flowerRotateLeft() { flowerRotY -= 5.0f; }
void CALLBACK flowerRotateRight() { flowerRotY += 5.0f; }

void CALLBACK flowerOrbitLeft() { flowerOrbitAngle -= 5.0f; }   
void CALLBACK flowerOrbitRight() { flowerOrbitAngle += 5.0f; }

void CALLBACK resetTransform() {
	transX = 0.0f; transY = 0.0f;
	rotAng = 0.0f; rotAngX = 0.0f; rotAngY = 0.0f;
	flowerTransX = 0.0f; flowerTransY = 0.0f; flowerTransZ = 0.0f;
	flowerRotY = 0.0f;
	flowerOrbitAngle = 0.0f;  
}

void CALLBACK display() {
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
	glLoadIdentity();

	GLfloat light_position[] = { 0.0, 200.0, 200.0, 1.0 };
	glLightfv(GL_LIGHT0, GL_POSITION, light_position);

	gluLookAt(eyeX, eyeY, eyeZ,
		centerX, centerY, centerZ,
		0.0, 1.0, 0.0);

	glMatrixMode(GL_MODELVIEW);

	glTranslatef(0.0f, 0.0f, -400.0f);

	glRotatef(rotAng, 1.0f, 1.0f, 1.0f);
	glRotatef(rotAngX, 1.0f, 0.0f, 0.0f);
	glRotatef(rotAngY, 0.0f, 1.0f, 0.0f);
	glTranslatef(transX, transY, 0.0f);

	drawVase();

	drawThreeFlowers();

	drawMyNameOverlay();

	auxSwapBuffers();
}

void CALLBACK myReshape(GLsizei w, GLsizei h)
{
	if (!h) return;
	glViewport(0, 0, w, h);

	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	gluPerspective(45.0f, (GLfloat)w / (GLfloat)h, 0.1f, 1000.0f);

	glMatrixMode(GL_MODELVIEW);
}

int main(int argc, char** argv)
{
	auxInitDisplayMode(AUX_DOUBLE | AUX_RGB | AUX_DEPTH16);
	auxInitPosition(100, 100, 800, 600);
	auxInitWindow("FloralVase");
	myInit();

	auxKeyFunc(AUX_z, moveForward);   
	auxKeyFunc(AUX_x, moveBackward);  
	auxKeyFunc(AUX_r, cameraUp);      
	auxKeyFunc(AUX_f, cameraDown);    
	auxKeyFunc(AUX_q, cameraLeft);    
	auxKeyFunc(AUX_e, cameraRight);   

	auxKeyFunc(AUX_t, lookUp);        
	auxKeyFunc(AUX_g, lookDown);      

	auxKeyFunc(AUX_a, moveLeft);      
	auxKeyFunc(AUX_d, moveRight);     
	auxKeyFunc(AUX_w, moveUp);        
	auxKeyFunc(AUX_s, moveDown);      

	auxKeyFunc(AUX_LEFT, transLeft);     
	auxKeyFunc(AUX_RIGHT, transRight);    
	auxKeyFunc(AUX_UP, transUpward);   
	auxKeyFunc(AUX_DOWN, transDownward); 

	auxKeyFunc(AUX_0, resetCamera);   
	auxKeyFunc(AUX_9, resetTransform); 
	auxKeyFunc(AUX_ESCAPE, exitApp);
	
	auxKeyFunc(AUX_1, flowerLeft);      
	auxKeyFunc(AUX_2, flowerRight);     
	auxKeyFunc(AUX_3, flowerUp);        
	auxKeyFunc(AUX_4, flowerDown);      
	auxKeyFunc(AUX_5, flowerForward);   
	auxKeyFunc(AUX_6, flowerBackward);  
	auxKeyFunc(AUX_7, flowerRotateLeft);  
	auxKeyFunc(AUX_8, flowerRotateRight); 

	auxKeyFunc(AUX_j, flowerOrbitLeft);
	auxKeyFunc(AUX_k, flowerOrbitRight);

	auxReshapeFunc(myReshape);
	auxMainLoop(display);

	return 0;
}