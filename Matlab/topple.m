
m = 0.00456; %mass of domino
g = 9.82;%gravity
H = 0.04353; %height
B = 0.02156; %width
T = 0.00679; %thickness

r = sqrt(H^2 + T^2); %distance from where force hits to pivot point

tTot = 1; %total time of simulation
h = 0.0005; %step length
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
taoTot = force(t)*r - g*m*d(theta(n), T, H, n); %total torque
ang_acc(n+1) = taoTot/J; %a is angle acceleration
omega(n+1) = omega(n) + h*ang_acc(n);
theta(n+1) = theta(n) + h*omega(n);

if (theta(n+1)<0)
theta(n+1) = 0;
omega(n+1) = 0;
ang_acc(n+1) = 0;
break;
end

if (theta(n+1)>0.001)
retur = 1;
end

if abs(theta(n+1)) < 0.0005
if retur == 1
omega(n+1) = 0;
ang_acc(n+1) = 0;
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
p1 = plot(t,ang_acc);
title('Angular acceleration')

subplot(1,3,2)
p2 = plot(t,omega);
title('Angular velocity')

subplot(1,3,3)
p3 = plot(t, theta);
title('Angle')





