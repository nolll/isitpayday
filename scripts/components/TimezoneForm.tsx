import { useState } from 'react';
import type { Timezone } from '@/types/Timezone';

interface Props {
  value: string;
  timezones: Timezone[];
  onChange: (value: string) => void;
}

export const TimezoneForm = ({ value, timezones, onChange }: Props) => {
  const [isFormVisible, setIsFormVisible] = useState(false);

  const timezoneName = timezones.find((t) => t.id === value)?.name ?? '';

  const handleChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
    setIsFormVisible(false);
    onChange(event.target.value);
  };

  if (!timezones.length) return null;

  return (
    <div>
      <h3>Timezone</h3>
      <div className="timezone-info">
        <p style={{ display: isFormVisible ? '' : 'none' }}>
          <select value={value} onChange={handleChange}>
            {timezones.map((t) => (
              <option value={t.id} key={t.id}>
                {t.name}
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
          {timezoneName}{' '}
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
};
