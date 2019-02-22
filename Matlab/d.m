function [ d ] = d(theta, T, H, n)

l = sqrt((H/2)^2 + (T/2)^2); %distance from center of mass to pivot point

if n == 1
    d = T/2;
else if theta > atan(T/H)
    d = -l*sin(theta);
else
    d = l*sin(theta);
end


end

