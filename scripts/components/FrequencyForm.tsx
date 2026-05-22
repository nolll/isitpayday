import { useState } from 'react';
import type { Frequency } from '@/types/Frequency';

interface Props {
  value: string;
  frequencies: Frequency[];
  onChange: (value: string) => void;
}

export default function FrequencyForm({ value, frequencies, onChange }: Props) {
  const [isFormVisible, setIsFormVisible] = useState(false);

  const frequencyName = frequencies.find((f) => f.id === value)?.name ?? '';

  const handleChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
    setIsFormVisible(false);
    onChange(event.target.value);
  };

  return (
    <div>
      <h3>Frequency</h3>
      <div className="frequency-info">
        <p style={{ display: isFormVisible ? '' : 'none' }}>
          <select value={value} onChange={handleChange}>
            {frequencies.map((f) => (
              <option value={f.id} key={f.id}>
                {f.name}
              </option>
            ))}
          </select>
          <a
            href="#"
            onClick={(e) => {
              e.preventDefault();
              setIsFormVisible(false);
            }}
          >
            Cancel
          </a>
        </p>
        <p style={{ display: isFormVisible ? 'none' : '' }}>
          {frequencyName}{' '}
          <a
            href="#"
            onClick={(e) => {
              e.preventDefault();
              setIsFormVisible(true);
            }}
          >
            Change
          </a>
        </p>
      </div>
    </div>
  );
}
