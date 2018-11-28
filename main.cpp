
#include <dlib/image_processing/frontal_face_detector.h>
#include <dlib/image_processing/render_face_detections.h>
#include <dlib/image_processing.h>
#include <dlib/gui_widgets.h>
#include <dlib/image_io.h>
#include <iostream>
#include<fstream>
#include<string>

using namespace dlib;
using namespace std;

int main(int argc, char** argv)
{
	try
	{

		frontal_face_detector detector = get_frontal_face_detector();//定义一个实体
		shape_predictor sp;
		deserialize("shape_predictor_68_face_landmarks.dat") >> sp;


		image_window win, win_faces;//显示窗口
			array2d<rgb_pixel> img;
			load_image(img, argv[1]);
			string str = argv[1];
			string str1(str,0, (str.length() - 4));
			string str2 = str1 + ".txt";
			cout <<endl<< "当前检测图片：" << argv[1] << endl;
			ofstream out(str2);
			cout <<"当前图片人脸关键点存储位置："<< str2 << endl<<endl;

			std::vector<rectangle> dets = detector(img);
			cout << "检测人脸数量: " << dets.size() << endl;

			std::vector<full_object_detection> shapes;
			for (unsigned long j = 0; j < dets.size(); ++j)
			{
				full_object_detection shape = sp(img, dets[j]);
				cout << "检测关键点数量：" << shape.num_parts() << endl;
				cout << "请稍等..." << endl;
				
				for (int i = 0; i < 68; i++)
				{
					out << shape.part(i).x() << " " << shape.part(i).y() << endl;
				}
				shapes.push_back(shape);
				out.close();
			}

			win.clear_overlay();
			win.set_image(img);
			win.add_overlay(render_face_detections(shapes));

			dlib::array<array2d<rgb_pixel> > face_chips;
			extract_image_chips(img, get_face_chip_details(shapes), face_chips);
			win_faces.set_image(tile_images(face_chips));

			cout << endl<<"检测完成！按Enter键退出." << endl;
			cin.get();
		}
	catch (exception& e)
	{
		cout << "\nexception thrown!" << endl;
		cout << e.what() << endl;
	}

}


