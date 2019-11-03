import math

# energy produced by 1 panel in kwh
ENERGYPERPANEL = 42
COSTPERPANEL = 584.51

def calculateEnergy(sqFt, residents):
    result = (93*residents) + 190 + (255 * math.exp(0.0006 * sqFt))
    return result

def calculateCost(monthlyEnergyConsumed):
    panelsNeeded = monthlyEnergyConsumed/ENERGYPERPANEL
    return panelsNeeded * COSTPERPANEL

print(calculateCost(calculateEnergy(4500,3)))