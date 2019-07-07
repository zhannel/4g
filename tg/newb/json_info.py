import json
import main

def get_json():
    arr_tasks = []
    count =0
    json_data = main.get_updates()
    for i in json_data['result']:
        list = i['message']['text']
        arr_tasks.append(list)
        count= count+1
        print(list)

    # for a in range(1, count):

    print(arr_tasks)
    print(count)
    # for i in json_data['result'][-1]:
    # another = json.load(json_data)
    # print(another)
