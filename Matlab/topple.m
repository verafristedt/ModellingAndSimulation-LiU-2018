clear all

m = 0.00456; %mass of domino
g = 9.82; %gravity
H = 0.04353; %height
B = 0.02156; %width
T = 0.00679; %thickness

r = sqrt(H^2 + T^2); %distance from where force hits to pivot point

tTot = 0.1; %total time of simulation
h = 0.0005; %step length
N = tTot/h; %number of samples

ang_acc = zeros(1,N); %angular acceleration
omega = zeros(1,N); %angular velocity
theta = zeros(1,N); %angle

J = m*(H^2+T^2)/12; %3moment of inertia

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

if (theta(n+1) < 0)
theta(n+1) = 0;
omega(n+1) = 0;
ang_acc(n+1) = 0;
break;
end

if (theta(n+1) > 0.001)
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

%%

dist = 0.02;
b = acos(dist/H);

k1 = max(find(theta < b+0.001));
k2 = min(find(theta > b-0.001));
k = min(k1, k2)
nspan = 4;

F = J*ang_acc(k)/H

%F = J*(omega(k) - omega(k-nspan))/((H*nspan)/h)

%F = m*ang_acc(k)*H

%%

tTot2 = 0.02; %total time of simulation
h2 = 0.0005; %step length
N2 = tTot2/h2; %number of samples

ang_acc = zeros(1,N2); %angular acceleration
omega = zeros(1,N2); %angular velocity
theta = zeros(1,N2); %angle

i = 1;
retur2 = 0;

for t=0:h2:(tTot2-h2)

if i==N2
break;
end

taoTot = force2(t,F)*r - g*m*d(theta(i), T, H, i); %total torque
ang_acc(i+1) = taoTot/J; %a is angle acceleration
omega(i+1) = omega(i) + h*ang_acc(i);
theta(i+1) = theta(i) + h*omega(i);

if (theta(i+1)<0)
theta(i+1) = 0;
omega(i+1) = 0;
ang_acc(i+1) = 0;
break;
end

if (theta(i+1)>0.001)
retur2 = 1;
end

if abs(theta(i+1)) < 0.0005
if retur2 == 1
omega(i+1) = 0;
ang_acc(i+1) = 0;
break;
end
end

if theta(i+1) >= pi/2
theta(i+1:N2) = pi/2;
ang_acc(i+1) = 0;
omega(i+1) = 0;
break;
end

i = i+1;
end

t2 = (0:h2:tTot2-h2);

subplot(1,3,1)
p1 = plot(t2,ang_acc);
title('Angular acceleration')

subplot(1,3,2)
p2 = plot(t2,omega);
title('Angular velocity')

subplot(1,3,3)
p3 = plot(t2, theta);
title('Angle')



