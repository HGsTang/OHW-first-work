// 星座运势2.0.cpp: 定义控制台应用程序的入口点。
// 星座运势.cpp: 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#include <windows.h> 
#include <stdio.h>

#include<iostream>
using namespace std;
class Date
{
	int day;
	int month;
	int year;
	int flag;

public:
	Date(int a, int b, int c) { year = a; month = b; day = c; }
	int runian() {
		if (year % 4 == 0 && year % 100 != 0)
		{
			//cout << "是闰年" << endl;
			flag = 1;
			return 1;
		}
		else if (year % 400 == 0)
		{
			//cout << "是闰年" << endl;
			flag = 1;
			return 1;
		}
		else {
			//cout << "不是闰年" << endl;
			flag = 0;
			return 0;
		}
	}
	int date() {
		int a[12] = { 31,28,31,30,31,30,31,31,30,31,30,31 };
		int i, x = 0;
		for (i = 0; i<month - 1; i++)
			x += a[i];
		x = x + day;
		if (month>2)
			if (flag)
				x++;
		return x;
	}

};
//判断是否闰年
int runnian(int year)
{
	if (year % 4 == 0 && year % 100 != 0)
	{
		return 1;
	}
	else if (year % 400 == 0)
	{
		return 1;
	}
	else
	{
		return 0;
	}
}
int xingzuo(int bornmonth,int bornday )
{
	int constellation_num;
	if (bornmonth == 1 && bornday >= 20)
	{
		//cout << "这天是水瓶座" << endl;
		constellation_num = 1;
	}
	else if (bornmonth == 2 && bornday <= 18)
	{
		//cout << "这天是水瓶座" << endl;
		constellation_num = 1;
	}
	else if (bornmonth == 2 && bornday > 18)
	{
		//cout << "这天是双鱼座" << endl;
		constellation_num = 2;
	}
	else if (bornmonth == 3 && bornday <= 20)
	{
		//cout << "这天是双鱼座" << endl;
		constellation_num = 2;
	}
	else if (bornmonth == 3 && bornday > 20)
	{
		//cout << "这天是白羊座" << endl;
		constellation_num = 3;
	}
	else if (bornmonth == 4 && bornday <= 19)
	{
		//cout << "这天是白羊座" << endl;
		constellation_num = 3;
	}

	else if (bornmonth == 4 && bornday >= 20)
	{
		//cout << "这天是金牛座" << endl;
		constellation_num = 4;
	}
	else if (bornmonth == 5 && bornday <= 20)
	{
		//cout << "这天是金牛座" << endl;
		constellation_num = 4;
	}
	else if (bornmonth == 5 && bornday >= 21)
	{
		//cout << "这天是双子座" << endl;
		constellation_num = 5;
	}
	else if (bornmonth == 6 && bornday <= 21)
	{
		//cout << "这天是双子座" << endl;
		constellation_num = 5;
	}
	else if (bornmonth == 6 && bornday >= 22)
	{
		//cout << "这天是巨蟹座" << endl;
		constellation_num = 6;
	}
	else if (bornmonth == 7 && bornday <= 22)
	{
		//cout << "这天是巨蟹座" << endl;
		constellation_num = 6;
	}
	else if (bornmonth == 7 && bornday >= 23)
	{
		//cout << "这天是狮子座" << endl;
		constellation_num = 7;
	}
	else if (bornmonth == 8 && bornday <= 22)
	{
		//cout << "这天是狮子座" << endl;
		constellation_num = 7;
	}
	else if (bornmonth == 8 && bornday >= 23)
	{
		//cout << "这天是处女座" << endl;
		constellation_num = 8;
	}
	else if (bornmonth == 9 && bornday <= 22)
	{
		//cout << "这天是处女座" << endl;
		constellation_num = 8;
	}
	else if (bornmonth == 9 && bornday >= 23)
	{
		//cout << "这天是天秤座" << endl;
		constellation_num = 9;
	}
	else if (bornmonth == 10 && bornday <= 23)
	{
		//cout << "这天是天秤座" << endl;
		constellation_num = 9;
	}
	else if (bornmonth == 10 && bornday >= 24)
	{
		//cout << "这天是天蝎座" << endl;
		constellation_num = 10;
	}
	else if (bornmonth == 11 && bornday <= 22)
	{
		//cout << "这天是天蝎座" << endl;
		constellation_num = 10;
	}
	else if (bornmonth == 11 && bornday >= 23)
	{
		//cout << "这天是射手座" << endl;
		constellation_num = 11;
	}
	else if (bornmonth == 12 && bornday <= 21)
	{
		//cout << "这天是射手座" << endl;
		constellation_num = 11;
	}
	else if (bornmonth == 12 && bornday >= 22)
	{
		//cout << "这天是摩羯座" << endl;
		constellation_num = 12;
	}
	else if (bornmonth == 1 && bornday <= 19)
	{
		//cout << "这天是摩羯座" << endl;
		constellation_num = 12;
	}
	return constellation_num;
}





int main(void)
{
	SYSTEMTIME sys;
	GetLocalTime(&sys);
	//printf("%4d/%02d/%02d ", sys.wYear, sys.wMonth, sys.wDay);
	cout << "今年是  " << sys.wYear << "年  " << sys.wMonth << "月  " << sys.wDay << "日" << endl;
	Date k(sys.wYear, sys.wMonth, sys.wDay);//今天————k
	int bornyear, bornmonth, bornday;
	int choose,choose2;
	int gap;
	int livingdays, i;//已活天数
	int constellation_num, today_num;
	int choose3,choose4;
	today_num = k.date();
	cout << "要输入 年/月/日，请输入1" << endl;
	cout << "要输入 月/日，请输入2" << endl;
	cin >> choose;
	
	if (choose == 1)
	{
		cout << "请输入您的出生日期" << endl;
		cin >> bornyear >> bornmonth >> bornday;//生日————k
		Date j(bornyear, bornmonth, bornday);
		Date l(sys.wYear, bornmonth, bornday);

		if (runnian(bornyear))
			livingdays = 366 - j.date();
		else livingdays = 365 - j.date();
		for (i = sys.wYear; i > bornyear + 1; i--)
		{
			if (runnian(i))
				livingdays = livingdays + 366;
			else livingdays = livingdays + 365;
		}


		cout << "请选择功能：" << endl;
		cout << "1.查询下一个生日及出生了多少天，输入1" << endl;
		cout << "2.查询星座，输入2" << endl;
		cout << "3.查询当日运势输入3" << endl;
		cin >> choose2;
		

		if(choose2==1)
		{
			cout << "您今年 " << sys.wYear - bornyear << "岁" << endl;
			if (l.date()> k.date() || l.date() == k.date())
			{
				gap = l.date() - k.date();
				cout << "距离下一个生日还有" << gap << "天" << endl;
			}
			else
			{
				if (runnian(sys.wYear))
					gap = 366 - k.date() + j.date();
				else gap = 365 - k.date() + j.date();
				cout << "距离下一个生日还有" << gap << "天" << endl;
			}
			cout << "您已经出生了" << livingdays + k.date() << "天" << endl;


		}
		else if (choose2 == 2)
		{
			switch (xingzuo(bornmonth, bornday))
			{
			case 1:
				cout << "您是水瓶座" << endl;
				break;
			case 2:
				cout << "您是双鱼座" << endl;
				break;
			case 3:
				cout << "您是白羊座" << endl;
				break;
			case 4:
				cout << "您是金牛座" << endl;
				break;
			case 5:
				cout << "您是双子座" << endl;
				break;
			case 6:
				cout << "您是巨蟹座" << endl;
				break;
			case 7:
				cout << "您是狮子座" << endl;
				break;
			case 8:
				cout << "您是处女座" << endl;
				break;
			case 9:
				cout << "您是天秤座" << endl;
				break;
			case 10:
				cout << "您是天蝎座" << endl;
				break;
			case 11:
				cout << "您是射手座" << endl;
			case 12:
				cout << "您是摩羯座" << endl;
				break;
			default:
				cout << "输入错误" << endl;
		    }

		}
		else if (choose2 == 3)
		{
			constellation_num = xingzuo(bornmonth, bornday);
			if (    ( today_num + xingzuo(bornmonth, bornday)) % 9 == 0      )
				cout << "爱他就要说出来，你不说他（她）怎么会知道呢？宜放手去爱不要逃" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 8 == 0)
				cout << "今天的财运旺盛，适合做投资和理财，会得到惊喜呦" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 7 == 0)
				cout << "健康运良好；适当食用带有咸味的食物，有利于运势" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 6 == 0)
				cout << "今天的事业运旺盛，凭着自己专业技能和认真的工作态度，领导早已属意与你，升职加薪指日可待,再换一台车也不是问题呦" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 5 == 0)
				cout << "今天的运势上多有不稳，做事难以顺心，心情难以舒畅，需要注意自我调整心态，毕竟和气才能生财吗！" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 4 == 0)
				cout << "好心情自然是要跟最重要的人一起分享，带着他（她）来一场说走就走的旅行吧。" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 3 == 0)
				cout << "今天的运势比较有利，做事多能达到自己的要求，但是还需要注意自我调整心态，不要对某件事耿耿于怀，以免影响自己的判断力而失去机会，得不偿失。" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 2 == 0)
				cout << "今天的运势是顺中有阻，可能会有一些原因导致事情进展的缓慢，但务必耐下性子，事情的结果并不会那么坏" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 13 == 0)
				cout << "有些事情看似都是在往好的方向发展，但是往往多为是虚假之象，结果并没有想象的那么好，因为今天会有小人出现，所以遇到事情的时候， 不要太相信别人，一定要慎重。" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 11 == 0)
				cout << "如果真的想在一起就不要再做无谓的争吵，这样不仅会伤感情，还会让彼此对未来失去信心。" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 17 == 0)
				cout << "谋事有阻，动荡不稳。工作上多有压力，受他人约束、管制较重，而且多会遭到小人在背后捣乱，诋毁自身形象。建议本月万事以“稳”为主，切忌强出头，如能做到多做少说，方可避免祸从口出，平安度过此月" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 19 == 0)
				cout << "运势急转直下，本月逢“六害星”所谓六害是指做事有破，他人迫害、陷害之意，因此说本月做事难以顺心，而且很容易遭受他人的算计而受到伤害，遇事需慎重，不可强求，最好做到不偏听、不偏信，脚踏实地做事为佳。" << endl;
			else
				cout << "　今天的你会有一种感觉，你对某些事物一时的兴趣似乎已经过去了。希望你保持平常心，该坚持的事情要坚持下去，不要因为一时觉得枯燥而放弃。" << endl;
		}
		else cout << "输入错误" << endl;
	}
	else if (choose == 2)
	{
		cout << "请输入您的出生日期" << endl;
		cin >> bornmonth >> bornday;//生日————k
		Date j(0, bornmonth, bornday);
		Date l(sys.wYear, bornmonth, bornday);

		cout << "请选择功能：" << endl;
		cout << "1.查询下一个生日，输入1" << endl;
		cout << "2.查询星座，输入2" << endl;
		cout << "3.查询当日运势输入3" << endl;
		cin >> choose2;

		if (choose2 == 1)
		{
			if (l.date()> k.date() || l.date() == k.date())
			{
				gap = l.date() - k.date();
				cout << "距离下一个生日还有" << gap << "天" << endl;
			}
			else
			{
				if (runnian(sys.wYear))
					gap = 366 - k.date() + j.date();
				else gap = 365 - k.date() + j.date();
				cout << "距离下一个生日还有" << gap << "天" << endl;
			}
		}
		else if (choose2 == 2)
		{
			switch (xingzuo(bornmonth, bornday))
			{
			case 1:
				cout << "您是水瓶座" << endl;
				break;
			case 2:
				cout << "您是双鱼座" << endl;
				break;
			case 3:
				cout << "您是白羊座" << endl;
				break;
			case 4:
				cout << "您是金牛座" << endl;
				break;
			case 5:
				cout << "您是双子座" << endl;
				break;
			case 6:
				cout << "您是巨蟹座" << endl;
				break;
			case 7:
				cout << "您是狮子座" << endl;
				break;
			case 8:
				cout << "您是处女座" << endl;
				break;
			case 9:
				cout << "您是天秤座" << endl;
				break;
			case 10:
				cout << "您是天蝎座" << endl;
				break;
			case 11:
				cout << "您是射手座" << endl;
			case 12:
				cout << "您是摩羯座" << endl;
				break;
			default:
				cout << "输入错误" << endl;
			}
		}
		else if (choose2 == 3)
		{
			constellation_num = xingzuo(bornmonth, bornday);
			if (                 (today_num + xingzuo(bornmonth, bornday)) % 9 == 0         )
				cout << "爱他就要说出来，你不说他（她）怎么会知道呢？宜放手去爱不要逃" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 8 == 0)
				cout << "今天的财运旺盛，适合做投资和理财，会得到惊喜呦" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 7 == 0)
				cout << "健康运良好；适当食用带有咸味的食物，有利于运势" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 6 == 0)
				cout << "今天的事业运旺盛，凭着自己专业技能和认真的工作态度，领导早已属意与你，升职加薪指日可待,再换一台车也不是问题呦" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 5 == 0)
				cout << "今天的运势上多有不稳，做事难以顺心，心情难以舒畅，需要注意自我调整心态，毕竟和气才能生财吗！" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 4 == 0)
				cout << "好心情自然是要跟最重要的人一起分享，带着他（她）来一场说走就走的旅行吧。" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 3 == 0)
				cout << "今天的运势比较有利，做事多能达到自己的要求，但是还需要注意自我调整心态，不要对某件事耿耿于怀，以免影响自己的判断力而失去机会，得不偿失。" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 2 == 0)
				cout << "今天的运势是顺中有阻，可能会有一些原因导致事情进展的缓慢，但务必耐下性子，事情的结果并不会那么坏" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 13 == 0)
				cout << "有些事情看似都是在往好的方向发展，但是往往多为是虚假之象，结果并没有想象的那么好，因为今天会有小人出现，所以遇到事情的时候， 不要太相信别人，一定要慎重。" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 11 == 0)
				cout << "如果真的想在一起就不要再做无谓的争吵，这样不仅会伤感情，还会让彼此对未来失去信心。" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 17 == 0)
				cout << "谋事有阻，动荡不稳。工作上多有压力，受他人约束、管制较重，而且多会遭到小人在背后捣乱，诋毁自身形象。建议本月万事以“稳”为主，切忌强出头，如能做到多做少说，方可避免祸从口出，平安度过此月" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 19 == 0)
				cout << "运势急转直下，本月逢“六害星”所谓六害是指做事有破，他人迫害、陷害之意，因此说本月做事难以顺心，而且很容易遭受他人的算计而受到伤害，遇事需慎重，不可强求，最好做到不偏听、不偏信，脚踏实地做事为佳。" << endl;
			else
				cout << "　今天的你会有一种感觉，你对某些事物一时的兴趣似乎已经过去了。希望你保持平常心，该坚持的事情要坚持下去，不要因为一时觉得枯燥而放弃。" << endl;
		}
		else cout << "输入错误" << endl;
	}
	else cout << "输入错误" << endl;


	cout << "请继续选择功能：" << endl;
	cout << "1.查询下一个生日，输入1" << endl;
	cout << "2.查询星座，输入2" << endl;
	cout << "3.查询当日运势输入3" << endl;
	cout << "4.退出请输入4" << endl;
	cin >> choose3;





	if (choose == 1)
	{



		if (choose3 == 1)
		{
			Date j(bornyear, bornmonth, bornday);
			Date l(sys.wYear, bornmonth, bornday);
			cout << "您今年 " << sys.wYear - bornyear << "岁" << endl;
			if (l.date()> k.date() || l.date() == k.date())
			{
				gap = l.date() - k.date();
				cout << "距离下一个生日还有" << gap << "天" << endl;
			}
			else
			{
				if (runnian(sys.wYear))
					gap = 366 - k.date() + j.date();
				else gap = 365 - k.date() + j.date();
				cout << "距离下一个生日还有" << gap << "天" << endl;
			}
			cout << "您已经出生了" << livingdays + k.date() << "天" << endl;


		}
		else if (choose3 == 2)
		{
			switch (xingzuo(bornmonth, bornday))
			{
			case 1:
				cout << "您是水瓶座" << endl;
				break;
			case 2:
				cout << "您是双鱼座" << endl;
				break;
			case 3:
				cout << "您是白羊座" << endl;
				break;
			case 4:
				cout << "您是金牛座" << endl;
				break;
			case 5:
				cout << "您是双子座" << endl;
				break;
			case 6:
				cout << "您是巨蟹座" << endl;
				break;
			case 7:
				cout << "您是狮子座" << endl;
				break;
			case 8:
				cout << "您是处女座" << endl;
				break;
			case 9:
				cout << "您是天秤座" << endl;
				break;
			case 10:
				cout << "您是天蝎座" << endl;
				break;
			case 11:
				cout << "您是射手座" << endl;
			case 12:
				cout << "您是摩羯座" << endl;
				break;
			default:
				cout << "输入错误" << endl;
			}

		}
		else if (choose3 == 3)
		{
			constellation_num = xingzuo(bornmonth, bornday);
			if ((today_num + xingzuo(bornmonth, bornday)) % 9 == 0)
				cout << "爱他就要说出来，你不说他（她）怎么会知道呢？宜放手去爱不要逃" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 8 == 0)
				cout << "今天的财运旺盛，适合做投资和理财，会得到惊喜呦" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 7 == 0)
				cout << "健康运良好；适当食用带有咸味的食物，有利于运势" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 6 == 0)
				cout << "今天的事业运旺盛，凭着自己专业技能和认真的工作态度，领导早已属意与你，升职加薪指日可待,再换一台车也不是问题呦" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 5 == 0)
				cout << "今天的运势上多有不稳，做事难以顺心，心情难以舒畅，需要注意自我调整心态，毕竟和气才能生财吗！" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 4 == 0)
				cout << "好心情自然是要跟最重要的人一起分享，带着他（她）来一场说走就走的旅行吧。" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 3 == 0)
				cout << "今天的运势比较有利，做事多能达到自己的要求，但是还需要注意自我调整心态，不要对某件事耿耿于怀，以免影响自己的判断力而失去机会，得不偿失。" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 2 == 0)
				cout << "今天的运势是顺中有阻，可能会有一些原因导致事情进展的缓慢，但务必耐下性子，事情的结果并不会那么坏" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 13 == 0)
				cout << "有些事情看似都是在往好的方向发展，但是往往多为是虚假之象，结果并没有想象的那么好，因为今天会有小人出现，所以遇到事情的时候， 不要太相信别人，一定要慎重。" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 11 == 0)
				cout << "如果真的想在一起就不要再做无谓的争吵，这样不仅会伤感情，还会让彼此对未来失去信心。" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 17 == 0)
				cout << "谋事有阻，动荡不稳。工作上多有压力，受他人约束、管制较重，而且多会遭到小人在背后捣乱，诋毁自身形象。建议本月万事以“稳”为主，切忌强出头，如能做到多做少说，方可避免祸从口出，平安度过此月" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 19 == 0)
				cout << "运势急转直下，本月逢“六害星”所谓六害是指做事有破，他人迫害、陷害之意，因此说本月做事难以顺心，而且很容易遭受他人的算计而受到伤害，遇事需慎重，不可强求，最好做到不偏听、不偏信，脚踏实地做事为佳。" << endl;
			else
				cout << "　今天的你会有一种感觉，你对某些事物一时的兴趣似乎已经过去了。希望你保持平常心，该坚持的事情要坚持下去，不要因为一时觉得枯燥而放弃。" << endl;
		}
		else if (choose3 == 4) return 0;
		else cout << "输入错误" << endl;
	}
	else if (choose == 2)
	{



		if (choose3 == 1)
		{
			Date j(1997, bornmonth, bornday);
			Date l(sys.wYear, bornmonth, bornday);

			if (l.date()> k.date() || l.date() == k.date())
			{
				gap = l.date() - k.date();
				cout << "距离下一个生日还有" << gap << "天" << endl;
			}
			else
			{
				if (runnian(sys.wYear))
					gap = 366 - k.date() + j.date();
				else gap = 365 - k.date() + j.date();
				cout << "距离下一个生日还有" << gap << "天" << endl;
			}
		}
		else if (choose3 == 2)
		{
			switch (xingzuo(bornmonth, bornday))
			{
			case 1:
				cout << "您是水瓶座" << endl;
				break;
			case 2:
				cout << "您是双鱼座" << endl;
				break;
			case 3:
				cout << "您是白羊座" << endl;
				break;
			case 4:
				cout << "您是金牛座" << endl;
				break;
			case 5:
				cout << "您是双子座" << endl;
				break;
			case 6:
				cout << "您是巨蟹座" << endl;
				break;
			case 7:
				cout << "您是狮子座" << endl;
				break;
			case 8:
				cout << "您是处女座" << endl;
				break;
			case 9:
				cout << "您是天秤座" << endl;
				break;
			case 10:
				cout << "您是天蝎座" << endl;
				break;
			case 11:
				cout << "您是射手座" << endl;
			case 12:
				cout << "您是摩羯座" << endl;
				break;
			default:
				cout << "输入错误" << endl;
			}
		}
		else if (choose3 == 3)
		{
			constellation_num = xingzuo(bornmonth, bornday);
			if ((today_num + xingzuo(bornmonth, bornday)) % 9 == 0)
				cout << "爱他就要说出来，你不说他（她）怎么会知道呢？宜放手去爱不要逃" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 8 == 0)
				cout << "今天的财运旺盛，适合做投资和理财，会得到惊喜呦" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 7 == 0)
				cout << "健康运良好；适当食用带有咸味的食物，有利于运势" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 6 == 0)
				cout << "今天的事业运旺盛，凭着自己专业技能和认真的工作态度，领导早已属意与你，升职加薪指日可待,再换一台车也不是问题呦" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 5 == 0)
				cout << "今天的运势上多有不稳，做事难以顺心，心情难以舒畅，需要注意自我调整心态，毕竟和气才能生财吗！" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 4 == 0)
				cout << "好心情自然是要跟最重要的人一起分享，带着他（她）来一场说走就走的旅行吧。" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 3 == 0)
				cout << "今天的运势比较有利，做事多能达到自己的要求，但是还需要注意自我调整心态，不要对某件事耿耿于怀，以免影响自己的判断力而失去机会，得不偿失。" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 2 == 0)
				cout << "今天的运势是顺中有阻，可能会有一些原因导致事情进展的缓慢，但务必耐下性子，事情的结果并不会那么坏" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 13 == 0)
				cout << "有些事情看似都是在往好的方向发展，但是往往多为是虚假之象，结果并没有想象的那么好，因为今天会有小人出现，所以遇到事情的时候， 不要太相信别人，一定要慎重。" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 11 == 0)
				cout << "如果真的想在一起就不要再做无谓的争吵，这样不仅会伤感情，还会让彼此对未来失去信心。" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 17 == 0)
				cout << "谋事有阻，动荡不稳。工作上多有压力，受他人约束、管制较重，而且多会遭到小人在背后捣乱，诋毁自身形象。建议本月万事以“稳”为主，切忌强出头，如能做到多做少说，方可避免祸从口出，平安度过此月" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 19 == 0)
				cout << "运势急转直下，本月逢“六害星”所谓六害是指做事有破，他人迫害、陷害之意，因此说本月做事难以顺心，而且很容易遭受他人的算计而受到伤害，遇事需慎重，不可强求，最好做到不偏听、不偏信，脚踏实地做事为佳。" << endl;
			else
				cout << "　今天的你会有一种感觉，你对某些事物一时的兴趣似乎已经过去了。希望你保持平常心，该坚持的事情要坚持下去，不要因为一时觉得枯燥而放弃。" << endl;
		}
		else if (choose3 == 4) return 0;
		else cout << "输入错误" << endl;
	}
	else cout << "输入错误" << endl;
	
	

	cout << "请继续选择功能：" << endl;
	cout << "1.查询下一个生日，输入1" << endl;
	cout << "2.查询星座，输入2" << endl;
	cout << "3.查询当日运势输入3" << endl;
	cout << "4.退出请输入4" << endl;
	cin >> choose4;






	if (choose == 1)
	{
		Date j(bornyear, bornmonth, bornday);
		Date l(sys.wYear, bornmonth, bornday);



		if (choose4 == 1)
		{
			cout << "您今年 " << sys.wYear - bornyear << "岁" << endl;
			if (l.date()> k.date() || l.date() == k.date())
			{
				gap = l.date() - k.date();
				cout << "距离下一个生日还有" << gap << "天" << endl;
			}
			else
			{
				if (runnian(sys.wYear))
					gap = 366 - k.date() + j.date();
				else gap = 365 - k.date() + j.date();
				cout << "距离下一个生日还有" << gap << "天" << endl;
			}
			cout << "您已经出生了" << livingdays + k.date() << "天" << endl;


		}
		else if (choose4== 2)
		{
			switch (xingzuo(bornmonth, bornday))
			{
			case 1:
				cout << "您是水瓶座" << endl;
				break;
			case 2:
				cout << "您是双鱼座" << endl;
				break;
			case 3:
				cout << "您是白羊座" << endl;
				break;
			case 4:
				cout << "您是金牛座" << endl;
				break;
			case 5:
				cout << "您是双子座" << endl;
				break;
			case 6:
				cout << "您是巨蟹座" << endl;
				break;
			case 7:
				cout << "您是狮子座" << endl;
				break;
			case 8:
				cout << "您是处女座" << endl;
				break;
			case 9:
				cout << "您是天秤座" << endl;
				break;
			case 10:
				cout << "您是天蝎座" << endl;
				break;
			case 11:
				cout << "您是射手座" << endl;
			case 12:
				cout << "您是摩羯座" << endl;
				break;
			default:
				cout << "输入错误" << endl;
			}

		}
		else if (choose4 == 3)
		{
			constellation_num = xingzuo(bornmonth, bornday);
			if ((today_num + xingzuo(bornmonth, bornday)) % 9 == 0)
				cout << "爱他就要说出来，你不说他（她）怎么会知道呢？宜放手去爱不要逃" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 8 == 0)
				cout << "今天的财运旺盛，适合做投资和理财，会得到惊喜呦" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 7 == 0)
				cout << "健康运良好；适当食用带有咸味的食物，有利于运势" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 6 == 0)
				cout << "今天的事业运旺盛，凭着自己专业技能和认真的工作态度，领导早已属意与你，升职加薪指日可待,再换一台车也不是问题呦" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 5 == 0)
				cout << "今天的运势上多有不稳，做事难以顺心，心情难以舒畅，需要注意自我调整心态，毕竟和气才能生财吗！" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 4 == 0)
				cout << "好心情自然是要跟最重要的人一起分享，带着他（她）来一场说走就走的旅行吧。" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 3 == 0)
				cout << "今天的运势比较有利，做事多能达到自己的要求，但是还需要注意自我调整心态，不要对某件事耿耿于怀，以免影响自己的判断力而失去机会，得不偿失。" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 2 == 0)
				cout << "今天的运势是顺中有阻，可能会有一些原因导致事情进展的缓慢，但务必耐下性子，事情的结果并不会那么坏" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 13 == 0)
				cout << "有些事情看似都是在往好的方向发展，但是往往多为是虚假之象，结果并没有想象的那么好，因为今天会有小人出现，所以遇到事情的时候， 不要太相信别人，一定要慎重。" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 11 == 0)
				cout << "如果真的想在一起就不要再做无谓的争吵，这样不仅会伤感情，还会让彼此对未来失去信心。" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 17 == 0)
				cout << "谋事有阻，动荡不稳。工作上多有压力，受他人约束、管制较重，而且多会遭到小人在背后捣乱，诋毁自身形象。建议本月万事以“稳”为主，切忌强出头，如能做到多做少说，方可避免祸从口出，平安度过此月" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 19 == 0)
				cout << "运势急转直下，本月逢“六害星”所谓六害是指做事有破，他人迫害、陷害之意，因此说本月做事难以顺心，而且很容易遭受他人的算计而受到伤害，遇事需慎重，不可强求，最好做到不偏听、不偏信，脚踏实地做事为佳。" << endl;
			else
				cout << "　今天的你会有一种感觉，你对某些事物一时的兴趣似乎已经过去了。希望你保持平常心，该坚持的事情要坚持下去，不要因为一时觉得枯燥而放弃。" << endl;
		}
		else if (choose4 == 4) return 0;
		else cout << "输入错误" << endl;
	}
	else if (choose == 2)
	{

		if (choose4 == 1)
		{
			Date j(bornyear, bornmonth, bornday);
			Date l(sys.wYear, bornmonth, bornday);

			if (l.date()> k.date() || l.date() == k.date())
			{
				gap = l.date() - k.date();
				cout << "距离下一个生日还有" << gap << "天" << endl;
			}
			else
			{
				if (runnian(sys.wYear))
					gap = 366 - k.date() + j.date();
				else gap = 365 - k.date() + j.date();
				cout << "距离下一个生日还有" << gap << "天" << endl;
			}
		}
		else if (choose4== 2)
		{
			switch (xingzuo(bornmonth, bornday))
			{
			case 1:
				cout << "您是水瓶座" << endl;
				break;
			case 2:
				cout << "您是双鱼座" << endl;
				break;
			case 3:
				cout << "您是白羊座" << endl;
				break;
			case 4:
				cout << "您是金牛座" << endl;
				break;
			case 5:
				cout << "您是双子座" << endl;
				break;
			case 6:
				cout << "您是巨蟹座" << endl;
				break;
			case 7:
				cout << "您是狮子座" << endl;
				break;
			case 8:
				cout << "您是处女座" << endl;
				break;
			case 9:
				cout << "您是天秤座" << endl;
				break;
			case 10:
				cout << "您是天蝎座" << endl;
				break;
			case 11:
				cout << "您是射手座" << endl;
			case 12:
				cout << "您是摩羯座" << endl;
				break;
			default:
				cout << "输入错误" << endl;
			}
		}
		else if (choose4 == 3)
		{
			constellation_num = xingzuo(bornmonth, bornday);
			if ((today_num + xingzuo(bornmonth, bornday)) % 9 == 0)
				cout << "爱他就要说出来，你不说他（她）怎么会知道呢？宜放手去爱不要逃" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 8 == 0)
				cout << "今天的财运旺盛，适合做投资和理财，会得到惊喜呦" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 7 == 0)
				cout << "健康运良好；适当食用带有咸味的食物，有利于运势" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 6 == 0)
				cout << "今天的事业运旺盛，凭着自己专业技能和认真的工作态度，领导早已属意与你，升职加薪指日可待,再换一台车也不是问题呦" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 5 == 0)
				cout << "今天的运势上多有不稳，做事难以顺心，心情难以舒畅，需要注意自我调整心态，毕竟和气才能生财吗！" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 4 == 0)
				cout << "好心情自然是要跟最重要的人一起分享，带着他（她）来一场说走就走的旅行吧。" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 3 == 0)
				cout << "今天的运势比较有利，做事多能达到自己的要求，但是还需要注意自我调整心态，不要对某件事耿耿于怀，以免影响自己的判断力而失去机会，得不偿失。" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 2 == 0)
				cout << "今天的运势是顺中有阻，可能会有一些原因导致事情进展的缓慢，但务必耐下性子，事情的结果并不会那么坏" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 13 == 0)
				cout << "有些事情看似都是在往好的方向发展，但是往往多为是虚假之象，结果并没有想象的那么好，因为今天会有小人出现，所以遇到事情的时候， 不要太相信别人，一定要慎重。" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 11 == 0)
				cout << "如果真的想在一起就不要再做无谓的争吵，这样不仅会伤感情，还会让彼此对未来失去信心。" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 17 == 0)
				cout << "谋事有阻，动荡不稳。工作上多有压力，受他人约束、管制较重，而且多会遭到小人在背后捣乱，诋毁自身形象。建议本月万事以“稳”为主，切忌强出头，如能做到多做少说，方可避免祸从口出，平安度过此月" << endl;
			else if ((today_num + xingzuo(bornmonth, bornday)) % 19 == 0)
				cout << "运势急转直下，本月逢“六害星”所谓六害是指做事有破，他人迫害、陷害之意，因此说本月做事难以顺心，而且很容易遭受他人的算计而受到伤害，遇事需慎重，不可强求，最好做到不偏听、不偏信，脚踏实地做事为佳。" << endl;
			else
				cout << "　今天的你会有一种感觉，你对某些事物一时的兴趣似乎已经过去了。希望你保持平常心，该坚持的事情要坚持下去，不要因为一时觉得枯燥而放弃。" << endl;
		}
		else if (choose4 == 4) return 0;
		else cout << "输入错误" << endl;
	}
	else cout << "输入错误" << endl;

	
	
	

	
	//if (j.runian())
		//cout << "是闰年" << endl;
	//else cout << "不是闰年" << endl;
	//cout << "这天是该年第" << j.date() << "天" << endl;

	

	
	return 0;
}