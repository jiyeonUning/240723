namespace gh_Day7_1
{

    /* 과제 1. 상속관계 구현하기
       지난 상속강의에서 제시된 과제 1의 내용을 추상클래스를 사용해 구현하시오.
       설계한 구조도에 맞춰 상속관계를 정의해야 한다.
       부모 객체가 가진 메서드를 자식 객체에서 공통적으로 사용하지만 구현내용이 달라야 하는 경우, 추상메서드로 선언하고 자식 객체에서는 이를 재정의한다.


        <조부모클래스 : 아이템> (조부모클래스까지 구현하려면 조조부모(플레이어 스탯) 조조조부모(플레이어)까지 만들어야 해서 생략)
        필드 : id, 아이템 이름, 아이템 최대갯수, 아이템 등급, 아이템 가격, 아이템 설명
        메서드:
        1. 아이템 사용
        2. 아이템 사용 시 효과 ( base(플레이어와 관련된 기능들이 상속된 조조부모클래스) )
        
        
        <부모클래스 : 동물>
        필드: 종류, 이름(플레이어가 입력), 부산물( base(아이템) ), 호감도 수치
        메서드:
        1. 먹이 주는 기능
        2. 부산물 생성
        2-1. 호감도에 따라 변동하는 부산물 등급
        3. 쓰다듬는 기능 (ex, 쓰다듬을 시 호감도 +0.5)
        4. 필드 정보 출력
        
        
        1. <자식클래스 : 닭>
        필드:
        종류 - 닭
        부산물 "달걀"
        추가 메서드 : 달걀 부화
        
        2. <자식클래스 : 토끼>
        필드:
        종류 - 토끼
        부산물 "토끼발"
        추가 메서드 : 교배
        
        3. <자식클래스 : 소>
        필드:
        종류 - 소
        부산물 "우유"
        추가 메서드 : 교배
    */


    /* < 오버라이딩 & 오버로딩, 그리고 추살 클래스의 정의 >
     
         오버라이딩 (override) :  virtual(가상함수), abstract(추상함수) 가 사용된 함수부분을 상속 받았을 때, 그것을 재정의할 때 사용되는 키워드.
                                  override 키워드 사용 시, 위 키워드가 사용된 함수를 같은 함수이름, 같은 매개변수로 재정의 하여서 자신만의 반응을 구현할 수 있게 된다.

                      오버로딩 : 다중정의 혹은 중복함수. 같은 함수명을 두고, 매개변수를 다르게 하여 함수를 여러개 만드는 것.
                            ex ) public int plus(int a, int b) 

                   추상 클래스 : 하나 이상의 추상함수를 포함하는 클래스.
                                 클래스가 추상적인 표현을 정의하는 경우, 자식클래스에서 구체화시켜 구현할 것을 염두해두고 추상화 시킨다.
                                 추상 클래스에서 내용을 구체화 할 수 없는 추상함수는 내용을 정의하지 않는다.
                                 추상 클래스를 상속하는 자식 클래스가 추상함수를 재정의하여, 구체화한 경우에 사용이 가능해진다.

                   +  abstract = 추상함수. 변경을 '허락'해주는 가상함수와는 달리, '강제로' 함수를 변경하게 만든다.                                                             */

    // 과제 문제점 : 호감도 +가 출력에서 반영이 되지 않음.

    public class Program
    {
        public abstract class Animal
        {                                                   // ~ 필드 ~
            public string AnimalType;                       // 종류
            protected string name;                          // 이름 (상속된 클래스에서만 사용 가능)
            public string ByProductItem;                    // 부산물
            public float Favorability = 0.0f;               // 호감도 수치 (0.5씩 오르기 때문에 float 자료형 사용)

            // ~ 메서드 ~
            public Animal()                                // 기본 수치 메서드            
            {
                AnimalType = "동물종";
                name = "동물이름";
                ByProductItem = "부산물아이템";
                Favorability = 0.5f;
            }

            public void Feed(string fodder = "여물")      // 먹이주기 기능 메서드            
            {
                Console.WriteLine("====================================");
                Console.WriteLine();
                Console.WriteLine($"{name}에게 {fodder}를 줍니다...");
                Console.WriteLine();
                Console.WriteLine(" . . . ");
                Favorability += 30.0f;
                Console.WriteLine();
                Console.WriteLine($"{name}의 호감도가 올랐습니다!");
                Console.WriteLine();
                Console.WriteLine("====================================");
            }

            public void ByProduct(int grade = 6)          // 부산물 생성, 호감도에 따른 부산물 등급 설정 기능 메서드
            {
                Console.WriteLine("============================================================");
                Console.WriteLine();
                Console.WriteLine($"{name}이(가) {ByProductItem}를 만들어냈습니다!");
                Console.WriteLine();
                Console.WriteLine("============================================================");

                if (Favorability >= 100)
                {
                    grade -= 5;
                    Console.WriteLine();
                    Console.WriteLine($"{ByProductItem}은 {grade}등급입니다.");
                }
                else if (Favorability >= 70)
                {
                    grade -= 4;
                    Console.WriteLine();
                    Console.WriteLine($"{ByProductItem}은 {grade}등급입니다.");
                }
                else if (Favorability >= 50)
                {
                    grade -= 3;
                    Console.WriteLine();
                    Console.WriteLine($"{ByProductItem}은 {grade}등급입니다.");
                }
                else if (Favorability >= 30)
                {
                    grade -= 2;
                    Console.WriteLine();
                    Console.WriteLine($"{ByProductItem}은 {grade}등급입니다.");
                }
                else if (Favorability >= 10)
                {
                    grade -= 1;
                    Console.WriteLine();
                    Console.WriteLine($"{ByProductItem}은 {grade}등급입니다.");
                }
                else  // 등급 없음
                {
                    Console.WriteLine();
                    Console.WriteLine($"{ByProductItem}은 평범합니다.");
                }
            }

            public void PetPet()                          // 쓰다듬는 기능 메서드
            {
                Console.WriteLine("====================================");
                Console.WriteLine();
                Console.WriteLine($"{name}을(를) 쓰다듬습니다...");
                Console.WriteLine();
                Console.WriteLine(" . . . ");
                Favorability += 15.5f;
                Console.WriteLine();
                Console.WriteLine($"{name}의 호감도가 올랐습니다!");
                Console.WriteLine();
                Console.WriteLine("====================================");
            }

            public abstract void AnimalData();                 // 동물(필드)의 정보 출력 메서드        

            public void AnimalDataInput()                      // 동물(필드)의 정보 출력 메서드2
            {
                Console.WriteLine("======================================");
                Console.WriteLine();
                Console.WriteLine("현재 동물들의 상태는 다음과 같습니다.");
                Console.WriteLine();
                Console.WriteLine("======================================");
                Console.WriteLine();
            }
        }


        public class Chicken : Animal   //   자식 클래스 : 닭
        {
            public Chicken()
            {
                AnimalType = "닭";
                name = "꼬꼬";
                ByProductItem = "달걀";
                Favorability = 50.0f;
            }

            public override void AnimalData()  // 추상함수 : 동물의 정보 출력 사용 = 오버라이딩 키워드 사용해주기
            {
                Console.WriteLine("===============================================");
                Console.WriteLine();
                Console.WriteLine($"종류 : {AnimalType}");
                Console.WriteLine($"이름 : {name}");
                Console.WriteLine($"부산물 종류 : {ByProductItem}");
                Console.WriteLine($"호감도 : {Favorability}");
                Console.WriteLine();
                Console.WriteLine("===============================================");
            }

            public void Incubation()  // 추가 메서드 : 부화
            {
                Console.WriteLine("===============================================");
                Console.WriteLine();
                Console.WriteLine($"{name}이(가) 달걀이 부화하려고 합니다...!");
                Console.WriteLine();
                Console.WriteLine(" . . . ");
                Console.WriteLine();
                Console.WriteLine("축하합니다! 건강한 병아리가 태어났습니다.");
                Console.WriteLine();
                Console.WriteLine("===============================================");
            }
        }

        public class Rabbit : Animal   //   자식 클래스 : 토끼
        {
            public Rabbit()
            {
                AnimalType = "토끼";
                name = "버니";
                ByProductItem = "토끼발";
                Favorability = 100.0f;
            }

            public override void AnimalData()  // 추상함수 : 동물의 정보 출력 사용 = 오버라이딩 키워드 사용해주기
            {
                Console.WriteLine("===============================================");
                Console.WriteLine();
                Console.WriteLine($"종류 : {AnimalType}");
                Console.WriteLine($"이름 : {name}");
                Console.WriteLine($"부산물 종류 : {ByProductItem}");
                Console.WriteLine($"호감도 : {Favorability}");
                Console.WriteLine();
                Console.WriteLine("===============================================");
            }

            public void Incubation()  // 추가 메서드 : 교배
            {
                Console.WriteLine("================================================================================================");
                Console.WriteLine();
                Console.WriteLine($"어느 날 아침, {name}이(가) 꿈에서 깨어났을 때 그는 자신이 부모가 되었다는 걸 깨달았다.");
                Console.WriteLine("축하합니다! 귀여운 아기토끼가 태어났습니다.");
                Console.WriteLine();
                Console.WriteLine("================================================================================================");
            }
        }

        public class Cow : Animal   //   자식 클래스 : 소
        {
            public Cow()
            {
                AnimalType = "소";
                name = "무우";
                ByProductItem = "우유";
                Favorability = 35.5f;
            }

            public override void AnimalData()  // 추상함수 : 동물의 정보 출력 사용 = 오버라이딩 키워드 사용해주기
            {
                Console.WriteLine("===============================================");
                Console.WriteLine();
                Console.WriteLine($"종류 : {AnimalType}");
                Console.WriteLine($"이름 : {name}");
                Console.WriteLine($"부산물 종류 : {ByProductItem}");
                Console.WriteLine($"호감도 : {Favorability}");
                Console.WriteLine();
                Console.WriteLine("===============================================");
            }

            public void Incubation()  // 추가 메서드 : 교배
            {
                Console.WriteLine("================================================================================================");
                Console.WriteLine();
                Console.WriteLine($"어느 날 아침, {name}이(가) 꿈에서 깨어났을 때 그는 자신이 부모가 되었다는 걸 깨달았다.");
                Console.WriteLine("축하합니다! 귀여운 송아지가 태어났습니다.");
                Console.WriteLine();
                Console.WriteLine("================================================================================================");
            }
        }


        static void Main(string[] args)
        {
            Chicken chicken = new Chicken();
            chicken.Feed();         // 먹이주기
            chicken.PetPet();       // 쓰다듬기
            chicken.ByProduct();    // 부산물 생산

            Console.WriteLine(); Console.WriteLine();

            Rabbit rabbit = new Rabbit();
            rabbit.Feed();        
            rabbit.PetPet();      
            rabbit.ByProduct();   

            Console.WriteLine(); Console.WriteLine();

            Cow cow = new Cow();
            cow.Feed();       
            cow.PetPet();     
            cow.ByProduct();  

            Console.WriteLine(); Console.WriteLine();

            Animal animal0 = new Chicken();  // 다운캐스팅 : 동물 정보 출력
            animal0.AnimalData();
            Console.WriteLine();

            Animal animal1 = new Rabbit();
            animal1.AnimalData();
            Console.WriteLine();

            Animal animal2 = new Cow();
            animal2.AnimalData();
            Console.WriteLine();
        }
    }
}
