

m = 1; %mass of block

g = 9.82;%gravity
H = 2;
B = 1;

r = sqrt(H^2 + B^2);

tTot = 10;%seconds
h = 0.005; % step length
N = tTot/h;%number of samples


a = zeros(1,N);
omega = zeros(1,N);
theta = zeros(1,N);



n = 1;

for t=0:h:tTot-h
    if n==N
        break;
    end
    a(n+1) = (1/(m*r^2))*((force(t)*r) - (g*m*d(theta(n), H, n))); %a is angle acceleration
    omega(n + 1) = omega(n) + h*a(n);
    theta (n+1) = theta(n) + h*omega(n);
    if theta(n+1) >= pi/2
        theta(n+1:N) = pi/2;
        a(n+1) = 0;
        omega(n+1) = 0;
        break;
    end
    
    n = n+1; 
end

t = (0:h:tTot-h);

subplot(1,3,1)
p1 = plot(t,a);
title('Angular acceleration')

subplot(1,3,2)
p2 = plot(t,omega);
title('Angular velocity')

subplot(1,3,3)
p3 = plot(t, theta);
title('Angle')





