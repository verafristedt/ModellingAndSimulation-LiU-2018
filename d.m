function [ d ] = d(theta, l, n)
if n == 1
d = l;
else
if theta > pi/4
    d = -l*sin(theta);
else
    d = l*sin(theta);
end
end

end

