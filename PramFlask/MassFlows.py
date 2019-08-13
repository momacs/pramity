def make_attributes_serializable(attr):
    keys = []
    vals = []
    for k, v in attr.items():
        keys.append(k)
        vals.append(v)
    return keys, vals

def get_mass_flow(s):
    redistributions = []
    for mfs in s.pop.last_iter.mass_flow_specs:
        for g_dst in mfs.dst:
            redistribution = {}

            source_dict = {}
            source_dict['attributeKeys'], source_dict['attributeValues'] = make_attributes_serializable(mfs.src.attr)
            if Site.AT in mfs.src.rel.keys():
                source_dict['site'] = mfs.src.rel[Site.AT]
            else:
                source_dict['site'] = None
            source_dict['n'] = 0

            destination_dict = {}
            destination_dict['attributeKeys'], destination_dict['attributeValues'] = make_attributes_serializable(g_dst.attr)
            if Site.AT in g_dst.rel.keys():
                destination_dict['site'] = g_dst.rel[Site.AT]
            else:
                destination_dict['site'] = None

            destination_dict['n'] = 0

            redistribution['source'] = source_dict
            redistribution['destination'] = destination_dict
            redistribution['mass'] = g_dst.m

            redistributions.append(redistribution)
    return {"redistributions": redistributions}

def run_and_get_mass_flow(s, number_of_iterations):
    simSteps = []
    for i in range(number_of_iterations):
        s.run(1)
        simSteps.append(get_mass_flow(s))
    return {"simSteps": simSteps}