#include <stdio.h>
#include <string.h>

struct Mark{
    char subject[80];
    float written;
    float practical;
};

void printMark(struct Mark *mark){
    printf("Subject: ");
    fgets((*mark).subject, 80, stdin);
    printf("Written: ");
    scanf("%f", &(*mark).written);
    printf("Practical: ");
    scanf("%f", &(*mark).practical);
};

int main(){
    struct Mark mark;
    printMark(&mark);
    
    printf("THONG TIN VE DIEM\n");
    printf("-----------------\n");
    printf("Mon Hoc: %s", mark.subject);
    printf("Diem LT: %.2f\n", mark.written);
    printf("Diem TH: %.2f\n", mark.practical);
    printf("Diem TB: %.2f\n", (mark.written + mark.practical) / 2);
    return 0;
}

