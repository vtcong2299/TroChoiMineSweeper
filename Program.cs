using System;

namespace TroChoiMineSweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            int row;
            int col;
            //Khai báo và khởi tạo bản đồ
            string[,] map = {
                            {"*", ".", ".", "."},
                            {".", ".", "*", "."},
                            {".", "*", ".", "."},
                            {".", ".", ".", "*"}
                            };
            //Xác định kích thước bản đồ
            int mapHeihgt = map.GetLength(0);
            int mapWidth = map.GetLength(1);
            //Khởi tạo mảng báo cáo
            string [,] mapReport = new string[mapHeihgt,mapWidth];
            //Duyệt qua từng ô của bản đồ
            for (row=0; row<mapHeihgt;row++)
            {
                for(col=0; col<mapWidth;col++)
                {
                    if (map[row,col]=="*")
                    {
                        mapReport[row,col]="*";
                    }
                    else
                    {
                        //Xử lý ô không phải mìn
                        //Xét các vị trí xung quanh, tiếp giáp với vị trí đang xét map[row,col]
                        int[,] nearBy = 
                        {
                            {row-1,col-1},
                            {row-1,col},
                            {row-1,col+1},
                            {row,col-1},
                            {row,col+1},
                            {row+1,col-1},
                            {row+1,col},
                            {row+1,col+1},
                        };
                        int count =0;
                        int length=nearBy.GetLength(0);
                        for (int i=0; i<length;i++)
                        {
                            int listRowOfNearBy= nearBy[i,0];
                            int listColOfNearBy= nearBy[i,1];
                            //Xét để loại các thành phần ngoài mảng
                            bool outOfNearBy = listRowOfNearBy<0||listRowOfNearBy>=mapHeihgt
                                            ||listColOfNearBy<0||listColOfNearBy>=mapWidth;
                            if (outOfNearBy==true)
                            {
                                continue;
                            }
                            //Nếu xung quang vị trí xét có giá trị "*" thì tăng biến đếm lên 1
                            bool checkNearBy = map[listRowOfNearBy,listColOfNearBy]=="*";
                            if (checkNearBy==true)
                            {
                                count++;
                            }                            
                        }
                        //Chuyển bến đếm count về dạng string
                        mapReport[row,col]=count.ToString();                    
                    }                    
                }
            }
            //In kết quả
            for (row=0; row<mapHeihgt;row++)
            {
                for(col=0; col<mapWidth;col++)
                {
                    Console.Write("{0,5}",mapReport[row,col]);
                }
                Console.WriteLine();
            }
        }
    }
}