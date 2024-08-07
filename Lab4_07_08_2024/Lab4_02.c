//Viết chương trình giải phương trình bậc hai ax^2 + bx + c = 0
#include <stdio.h>
#include <math.h>

int main(){
    float a, b, c, x1, x2, delta;
    printf("Nhập a ,b ,c: \n");
    scanf("%f%f%f", &a, &b, &c);
    
  if (a == 0){
    if (b == 0){
      if (c == 0){
        printf("Phương trình có vô số nghiệm\n");
      }else{
        printf("Phương trình vô nghiệm\n");
      }
    }else{
      x1 = -c/b;
      printf("Phương trình có nghiệm x = %.2f\n", x1);
    }
  } else{
    delta = b*b - 4*a*c;
    if (delta < 0){
      printf("Phương trình vô nghiệm\n");
    }else if (delta == 0){
      x1 = -b/(2*a);
      printf("Phương trình có nghiệm kép x = %.2f\n", x1);
    } else{
    x1 = (-b + sqrt(delta))/(2*a);
    x2 = (-b - sqrt(delta))/(2*a);
    printf("Phương trình có 2 nghiệm phân biệt x1 = %.2f và x2 = %.2f\n", x1, x2);
    }
  }
}