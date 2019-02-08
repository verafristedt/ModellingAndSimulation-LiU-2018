function [ d ] = d(theta, H, n)
if n == 1
    d = H/2;
else 
    if theta > pi/4
        d = -(H/2)*sin(theta);
    else
        d = (H/2)*sin(theta);
    end
end

end

