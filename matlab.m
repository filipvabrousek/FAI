M = [2, 3, 5; 7, 8, 1; 9, 2, 4]; 
N = randi([3 11], 3);% rand(3) * 1 + 10; % matrix in 3 - 11 interval
d = det(M); % M determinant
F = N.^2; % umocnění na 2
c2 = M(2: end, :); % 2. až poslední řádek
c3 = size(M); % délka každé dimenze M
c4 = eig(M);
%c4 = N(1,6,7,9); % zobrazte prvky 1, 6, 7, 9 matice N

S = M * N;
TransN =  N';

xd = [3, 7 ,-4; 5, -2, 8; 9, 1, -6];  %řešení soustavy
b =  [11, 13, 9]'; 
x = xd\b;

%resa = N(1:6:end);
%resb = N(6:7:end);
%resc = N(7:9:end);
a = N(1,1);
b = N(2,3);
c = N(3,1);
d = N(3,3);
minim = min(N);

