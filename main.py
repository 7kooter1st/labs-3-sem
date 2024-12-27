# import sys
#
# def get_coef(index, prompt):
#     try:
#         coef_str = sys.argv[index]
#     except:
#         print(prompt)
#         coef_str = input()
#     coef = float(coef_str)
#     return coef
#
# def get_sol(a,b,c):
#     D = -4 * a * c + b**2
#     if D > 0:
#         return (D,(-b-D**0.5)/(2*a),(-b+D**0.5)/(2*a))
#     elif D == 0:
#         return (D,-b/(2*a),-b/(2*a  ))
#     else:
#         return "не существует действительных решений"
#
# def print_sol(tuple):
#     if len(tuple)==3:
#         print("Дискриминат =",tuple[0])
#         print(f"Корни = {tuple[1:]}",sep='\n')
#     else:
#         print(tuple)
# def main():
#     a = get_coef(1,"введите коэффицент a")
#     b = get_coef(2,"введите коэффицент b")
#     c = get_coef(3,"введите коэффицент c")
#
#     solutions = get_sol(a,b,c)
#     print_sol(solutions)
#     return 0
#
# main()


import sys

class Coefficient:
    def __init__(self, C):
        self.coef = C

    def print_coef(self):
        print(self.coef)


class Equation:

    def __init__(self, a, b, c):
        self.a = Coefficient(a)
        self.b = Coefficient(b)
        self.c = Coefficient(c)
        self.D = self.b.coef**2 - 4 * self.a.coef * self.c.coef

    def print_coefficients(self):
        print("a:", self.a.coef)
        print("b:", self.b.coef)
        print("c:", self.c.coef)
        print("c:", self.D)
    def result(self):
        D = self.D
        a = self.a.coef
        b = self.b.coef
        c = self.c.coef

        if D > 0:
            print("дискриминант:", D, "\nкорни уравнения:", (-b - D ** 0.5) / (2 * a), (-b + D ** 0.5) / (2 * a))
        elif D == 0:
            print("дискриминант:", D)
            print("корень уравнения:", -b / (2 * a))
        else:
            print("не существует действительных решений")

def get_coef(index, prompt):
    try:
        coef_str = sys.argv[index]
    except:
        print(prompt)
        coef_str = input()
    coef = float(coef_str)
    return coef

def main():
    a = get_coef(1, "введите коэффицент a")
    b = get_coef(2, "введите коэффицент b")
    c = get_coef(3, "введите коэффицент c")
    eq = Equation(a, b, c)
    eq.result()

main()
