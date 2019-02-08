

m = 1; %mass of block
g = 9.82;%gravity
H = 2; %height
B = 1; %width
T = 0.2; %thickness

r = sqrt(H^2 + T^2); %distance from where force hits to pivot point
l = sqrt((H/2)^2 + (T/2)^2); %distance from center of mass to pivot point

tTot = 3; %total time of simulation
h = 0.005; %step length
N = tTot/h; %number of samples

ang_acc = zeros(1,N); %angular acceleration
omega = zeros(1,N); %angular velocity
theta = zeros(1,N); %angle

J = m*(H^2+T^2)/3; %moment of inertia

n = 1;
retur = 0;

for t=0:h:tTot-h
if n==N
break;
end
ang_acc(n+1) = (1/J)*((force(t)*r) - (g*m*d(theta(n), l, n))); %a is angle acceleration
omega(n + 1) = omega(n) + h*a(n);
theta (n+1) = theta(n) + h*omega(n);

if theta(n+1) > 0.01
retur = 1;
end
if abs(theta(n+1)) < 0.005
if retur == 1
omega(n+1) = 0;
break;
end
end

if theta(n+1) >= pi/2
theta(n+1:N) = pi/2;
ang_acc(n+1) = 0;
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





